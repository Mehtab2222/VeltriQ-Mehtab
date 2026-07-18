using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.InductionSessions;
using VeltriQ.ViewModels.InductionSessionTopics;

namespace VeltriQ.Controllers
{
    public class InductionSessionController : BaseController
    {
        public InductionSessionController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
        }



        public IActionResult Index()
        {
            var model = new InductionSessionIndexViewModel();

            // Load active programs into ViewBag for the dropdown
            var activePrograms = _context.InductionProgramMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.ProgramName)
                .Select(x => new SelectListItem
                {
                    Value = x.InductionProgramMasterId.ToString(),
                    Text = x.ProgramName
                })
                .ToList();

            ViewBag.Programs = activePrograms;

            // Automatically set the model's selected ID to the first available active program
            if (activePrograms.Any())
            {
                model.SelectedProgramId = int.Parse(activePrograms.First().Value);
            }

            return View(model);
        }


        private void LoadPrograms()
        {
            ViewBag.Programs = _context.InductionProgramMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.ProgramName)
                .Select(x => new SelectListItem
                {
                    Value = x.InductionProgramMasterId.ToString(),
                    Text = x.ProgramName
                })
                .ToList();
        }


        [HttpGet]
        public IActionResult GetSessions(int inductionProgramMasterId)
        {
            var sessions = _context.InductionSessionMasters
                .Include(x => x.InductionProgramMaster)
                .Where(x => x.InductionProgramMasterId == inductionProgramMasterId)
                .OrderBy(x => x.SessionOrder)
                .Select(x => new InductionSessionListItemViewModel
                {
                    InductionSessionMasterId = x.InductionSessionMasterId,
                    InductionProgramMasterId = x.InductionProgramMasterId,
                    ProgramName = x.InductionProgramMaster.ProgramName,
                    SessionCode = x.SessionCode,
                    SessionTitle = x.SessionTitle,
                    Description = x.Description,
                    SessionOrder = x.SessionOrder,
                    DurationInMinutes = x.DurationInMinutes,
                    IsMandatory = x.IsMandatory,
                    IsActive = x.IsActive,
                    CreatedOn = x.CreatedOn
                })
                .ToList();

            return Json(new
            {
                success = true,
                data = sessions
            });
        }



        private string GenerateSessionCode()
        {
            var lastSession = _context.InductionSessionMasters
                .OrderByDescending(x => x.InductionSessionMasterId)
                .FirstOrDefault();

            if (lastSession == null)
            {
                return "SES-0001";
            }

            int lastNumber = 0;

            if (!string.IsNullOrWhiteSpace(lastSession.SessionCode))
            {
                int.TryParse(
                    lastSession.SessionCode.Replace("SES-", ""),
                    out lastNumber);
            }

            return $"SES-{(lastNumber + 1):D4}";
        }


        [HttpGet]
        public IActionResult Create(int programId)
        {
            var program = _context.InductionProgramMasters
                .FirstOrDefault(x => x.InductionProgramMasterId == programId);

            if (program == null)
            {
                return NotFound();
            }

            var model = new InductionSessionCreateViewModel
            {
                InductionProgramMasterId = program.InductionProgramMasterId,
                ProgramName = program.ProgramName,
                IsMandatory = true,
                IsActive = true
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InductionSessionCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please correct the validation errors."
                    });
                }

                bool exists = _context.InductionSessionMasters.Any(x =>
                    x.InductionProgramMasterId == model.InductionProgramMasterId &&
                    x.SessionTitle.Trim().ToLower() == model.SessionTitle.Trim().ToLower());

                if (exists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "A session with the same title already exists for this induction program."
                    });
                }

                var session = new InductionSessionMaster
                {
                    InductionProgramMasterId = model.InductionProgramMasterId,
                    SessionCode = GenerateSessionCode(),
                    SessionTitle = model.SessionTitle.Trim(),
                    Description = model.Description?.Trim(),
                    SessionOrder = model.SessionOrder,
                    DurationInMinutes = model.DurationInMinutes,
                    IsMandatory = model.IsMandatory,
                    IsActive = model.IsActive,
                    CreatedOn = DateTime.Now,
                    CreatedBy = User.Identity?.Name
                };

                _context.InductionSessionMasters.Add(session);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Induction session created successfully."
                });
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while creating the induction session."
                });
            }
        }
        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var session = _context.InductionSessionMasters
                .Include(x => x.InductionProgramMaster)
                .FirstOrDefault(x => x.InductionSessionMasterId == id);

            if (session == null)
            {
                return NotFound();
            }

            var model = new InductionSessionEditViewModel
            {
                InductionSessionMasterId = session.InductionSessionMasterId,
                InductionProgramMasterId = session.InductionProgramMasterId,
                ProgramName = session.InductionProgramMaster?.ProgramName ?? string.Empty,
                SessionTitle = session.SessionTitle,
                Description = session.Description,
                SessionOrder = session.SessionOrder,
                DurationInMinutes = session.DurationInMinutes,
                IsMandatory = session.IsMandatory,
                IsActive = session.IsActive
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InductionSessionEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please correct the validation errors."
                    });
                }

                var session = _context.InductionSessionMasters
                    .FirstOrDefault(x => x.InductionSessionMasterId == model.InductionSessionMasterId);

                if (session == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Induction session not found."
                    });
                }

                bool exists = _context.InductionSessionMasters.Any(x =>
                    x.InductionSessionMasterId != model.InductionSessionMasterId &&
                    x.InductionProgramMasterId == model.InductionProgramMasterId &&
                    x.SessionTitle.Trim().ToLower() == model.SessionTitle.Trim().ToLower());

                if (exists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "A session with the same title already exists for this induction program."
                    });
                }

                session.SessionTitle = model.SessionTitle.Trim();
                session.Description = model.Description?.Trim();
                session.SessionOrder = model.SessionOrder;
                session.DurationInMinutes = model.DurationInMinutes;
                session.IsMandatory = model.IsMandatory;
                session.IsActive = model.IsActive;
                session.ModifiedOn = DateTime.Now;
                session.ModifiedBy = User.Identity?.Name;

                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Induction session updated successfully."
                });
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while updating the induction session."
                });
            }
        }

        #endregion
        #region Toggle Status

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            try
            {
                var session = _context.InductionSessionMasters
                    .FirstOrDefault(x => x.InductionSessionMasterId == id);

                if (session == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Induction session not found."
                    });
                }

                session.IsActive = !session.IsActive;
                session.ModifiedOn = DateTime.Now;
                session.ModifiedBy = User.Identity?.Name;

                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    isActive = session.IsActive,
                    message = session.IsActive
                        ? "Induction session activated successfully."
                        : "Induction session deactivated successfully."
                });
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while updating the session status."
                });
            }
        }

        #endregion
        //====================================================
        // GET NEXT SESSION SEQUENCE ORDER (AJAX GET)
        //====================================================
        [HttpGet]
        public IActionResult GetNextSessionOrder(int programId)
        {
            var maxOrder = _context.InductionSessionMasters
                .Where(x => x.InductionProgramMasterId == programId)
                .Select(x => (int?)x.SessionOrder)
                .Max() ?? 0;

            return Json(new { nextOrder = maxOrder + 1 });
        }
        #region Session Topics

        [HttpGet]
        public IActionResult GetTopics(int sessionId)
        {
            var session = _context.InductionSessionMasters
                .Include(x => x.InductionProgramMaster)
                .FirstOrDefault(x => x.InductionSessionMasterId == sessionId);

            if (session == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Session not found."
                });
            }

            var topics = _context.InductionSessionTopicMasters
                .Where(x => x.InductionSessionMasterId == sessionId)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new InductionSessionTopicListItemViewModel
                {
                    InductionSessionTopicMasterId = x.InductionSessionTopicMasterId,
                    DisplayOrder = x.DisplayOrder,
                    TopicName = x.TopicName,
                    IsActive = x.IsActive
                })
                .ToList();

            return Json(new
            {
                success = true,
                sessionId = session.InductionSessionMasterId,
                programName = session.InductionProgramMaster.ProgramName,
                sessionTitle = session.SessionTitle,
                topics = topics
            });
        }
        [HttpPost]
        public IActionResult AddTopic(InductionSessionTopicViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please enter a topic."
                    });
                }

                bool exists = _context.InductionSessionTopicMasters.Any(x =>
                    x.InductionSessionMasterId == model.InductionSessionMasterId &&
                    x.TopicName.Trim().ToLower() == model.TopicName.Trim().ToLower());

                if (exists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "This topic already exists for the selected session."
                    });
                }

                var topic = new InductionSessionTopicMaster
                {
                    InductionSessionMasterId = model.InductionSessionMasterId,
                    TopicName = model.TopicName.Trim(),
                    DisplayOrder = model.DisplayOrder,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = User.Identity?.Name
                };

                _context.InductionSessionTopicMasters.Add(topic);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Topic added successfully."
                });
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while adding the topic."
                });
            }
        }
        [HttpGet]
        public IActionResult GetTopic(int topicId)
        {
            var topic = _context.InductionSessionTopicMasters
                .FirstOrDefault(x => x.InductionSessionTopicMasterId == topicId);

            if (topic == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Topic not found."
                });
            }

            return Json(new
            {
                success = true,
                data = new InductionSessionTopicViewModel
                {
                    InductionSessionTopicMasterId = topic.InductionSessionTopicMasterId,
                    InductionSessionMasterId = topic.InductionSessionMasterId,
                    TopicName = topic.TopicName,
                    DisplayOrder = topic.DisplayOrder,
                    IsActive = topic.IsActive
                }
            });
        }
        [HttpPost]
        public IActionResult UpdateTopic(InductionSessionTopicViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please enter a topic."
                    });
                }

                var topic = _context.InductionSessionTopicMasters
                    .FirstOrDefault(x => x.InductionSessionTopicMasterId == model.InductionSessionTopicMasterId);

                if (topic == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Topic not found."
                    });
                }

                bool exists = _context.InductionSessionTopicMasters.Any(x =>
                    x.InductionSessionTopicMasterId != model.InductionSessionTopicMasterId &&
                    x.InductionSessionMasterId == model.InductionSessionMasterId &&
                    x.TopicName.Trim().ToLower() == model.TopicName.Trim().ToLower());

                if (exists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "This topic already exists for the selected session."
                    });
                }

                topic.TopicName = model.TopicName.Trim();
                topic.DisplayOrder = model.DisplayOrder;
                topic.IsActive = model.IsActive;
                topic.ModifiedOn = DateTime.Now;
                topic.ModifiedBy = User.Identity?.Name;

                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Topic updated successfully."
                });
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while updating the topic."
                });
            }
        }
        [HttpPost]
        public IActionResult ToggleTopicStatus(int topicId)
        {
            try
            {
                var topic = _context.InductionSessionTopicMasters
                    .FirstOrDefault(x => x.InductionSessionTopicMasterId == topicId);

                if (topic == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Topic not found."
                    });
                }

                topic.IsActive = !topic.IsActive;
                topic.ModifiedOn = DateTime.Now;
                topic.ModifiedBy = User.Identity?.Name;

                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    isActive = topic.IsActive,
                    message = topic.IsActive
                        ? "Topic activated successfully."
                        : "Topic deactivated successfully."
                });
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while updating the topic status."
                });
            }
        }

        #endregion
        //================════════════════════════════════════
        // RE-ORDER TOPICS VIA DRAG & DROP (AJAX POST)
        //================════════════════════════════════════
        [HttpPost]
        public IActionResult UpdateTopicsOrder(List<int> sortedTopicIds)
        {
            if (sortedTopicIds == null || !sortedTopicIds.Any())
            {
                return Json(new { success = false, message = "No parameters provided." });
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Re-index every item in the sequential array loop order
                for (int i = 0; i < sortedTopicIds.Count; i++)
                {
                    var topicId = sortedTopicIds[i];
                    var topic = _context.InductionSessionTopicMasters
                        .FirstOrDefault(x => x.InductionSessionTopicMasterId == topicId);

                    if (topic != null)
                    {
                        topic.DisplayOrder = i + 1; // 1-based index assignment
                        topic.ModifiedOn = DateTime.Now;
                        topic.ModifiedBy = User.Identity?.Name;
                    }
                }

                _context.SaveChanges();
                transaction.Commit();

                return Json(new { success = true, message = "Topics sequence re-ordered successfully." });
            }
            catch
            {
                transaction.Rollback();
                return Json(new { success = false, message = "An error occurred while updating the sequence." });
            }
        }
    }
}