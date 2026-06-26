using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeltriQ.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class AddOnboardingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnboardingTemplate_Department_DepartmentId",
                schema: "HR",
                table: "OnboardingTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_OnboardingTemplate_Designation_DesignationId",
                schema: "HR",
                table: "OnboardingTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_OnboardingTemplate_EmploymentTypeMaster_EmploymentTypeMasterId",
                schema: "HR",
                table: "OnboardingTemplate");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                schema: "HR",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityDocumentMaster",
                schema: "HR",
                columns: table => new
                {
                    IdentityDocumentMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HasExpiry = table.Column<bool>(type: "bit", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityDocumentMaster", x => x.IdentityDocumentMasterId);
                    table.ForeignKey(
                        name: "FK_IdentityDocumentMaster_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "HR",
                        principalTable: "Country",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployee",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OnboardingTemplateId = table.Column<int>(type: "int", nullable: false),
                    EmploymentTypeMasterId = table.Column<int>(type: "int", nullable: false),
                    OnboardingStatusMasterId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConvertedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPortalLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsConvertedToEmployee = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RecruitmentCandidateId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployee", x => x.OnboardingEmployeeId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployee_EmploymentTypeMaster_EmploymentTypeMasterId",
                        column: x => x.EmploymentTypeMasterId,
                        principalSchema: "HR",
                        principalTable: "EmploymentTypeMaster",
                        principalColumn: "EmploymentTypeMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployee_OnboardingStatusMaster_OnboardingStatusMasterId",
                        column: x => x.OnboardingStatusMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingStatusMaster",
                        principalColumn: "OnboardingStatusMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployee_OnboardingTemplate_OnboardingTemplateId",
                        column: x => x.OnboardingTemplateId,
                        principalSchema: "HR",
                        principalTable: "OnboardingTemplate",
                        principalColumn: "OnboardingTemplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualificationTypeMaster",
                schema: "HR",
                columns: table => new
                {
                    QualificationTypeMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationTypeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    QualificationTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationTypeMaster", x => x.QualificationTypeMasterId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "HR",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeActivity",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    OnboardingActivityMasterId = table.Column<int>(type: "int", nullable: false),
                    ActivityStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CompletedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    IsOverdue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeActivity", x => x.OnboardingEmployeeActivityId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeActivity_OnboardingActivityMaster_OnboardingActivityMasterId",
                        column: x => x.OnboardingActivityMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingActivityMaster",
                        principalColumn: "OnboardingActivityMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeActivity_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeAddress",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ResidenceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StayFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsSameAsPermanentAddress = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeAddress", x => x.OnboardingEmployeeAddressId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeAddress_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "HR",
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeAddress_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "HR",
                        principalTable: "Country",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeAddress_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeBank",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AccountHolderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IFSCCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SWIFTCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeBank", x => x.OnboardingEmployeeBankId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeBank_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeDocument",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    OnboardingDocumentMasterId = table.Column<int>(type: "int", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    DocumentStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VersionNo = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    UploadedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeDocument", x => x.OnboardingEmployeeDocumentId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeDocument_OnboardingDocumentMaster_OnboardingDocumentMasterId",
                        column: x => x.OnboardingDocumentMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingDocumentMaster",
                        principalColumn: "OnboardingDocumentMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeDocument_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeEmergencyContact",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeEmergencyContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AlternateMobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LivesWithEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimaryContact = table.Column<bool>(type: "bit", nullable: false),
                    PriorityOrder = table.Column<int>(type: "int", nullable: false),
                    IsAuthorizedToReceiveInformation = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeEmergencyContact", x => x.OnboardingEmployeeEmergencyContactId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeEmergencyContact_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "HR",
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeEmergencyContact_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "HR",
                        principalTable: "Country",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeEmergencyContact_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeIdentity",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeIdentityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    IdentityDocumentMasterId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeIdentity", x => x.OnboardingEmployeeIdentityId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeIdentity_IdentityDocumentMaster_IdentityDocumentMasterId",
                        column: x => x.IdentityDocumentMasterId,
                        principalSchema: "HR",
                        principalTable: "IdentityDocumentMaster",
                        principalColumn: "IdentityDocumentMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeIdentity_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeePersonal",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeePersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MotherTongue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDifferentlyAbled = table.Column<bool>(type: "bit", nullable: false),
                    DisabilityDetails = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeePersonal", x => x.OnboardingEmployeePersonalId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePersonal_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalSchema: "HR",
                        principalTable: "Nationality",
                        principalColumn: "NationalityId");
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePersonal_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeePolicyAcceptance",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeePolicyAcceptanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    OnboardingPolicyMasterId = table.Column<int>(type: "int", nullable: false),
                    PolicyVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    AcceptanceStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AcceptedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcceptanceMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RequiresReAcceptance = table.Column<bool>(type: "bit", nullable: false),
                    AcceptanceRemarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeePolicyAcceptance", x => x.OnboardingEmployeePolicyAcceptanceId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePolicyAcceptance_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeePolicyAcceptance_OnboardingPolicyMaster_OnboardingPolicyMasterId",
                        column: x => x.OnboardingPolicyMasterId,
                        principalSchema: "HR",
                        principalTable: "OnboardingPolicyMaster",
                        principalColumn: "OnboardingPolicyMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualificationMaster",
                schema: "HR",
                columns: table => new
                {
                    QualificationMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationTypeMasterId = table.Column<int>(type: "int", nullable: false),
                    QualificationCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    QualificationName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RequiresExpiryDate = table.Column<bool>(type: "bit", nullable: false),
                    IsProfessionalQualification = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequiresRenewal = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationMaster", x => x.QualificationMasterId);
                    table.ForeignKey(
                        name: "FK_QualificationMaster_QualificationTypeMaster_QualificationTypeMasterId",
                        column: x => x.QualificationTypeMasterId,
                        principalSchema: "HR",
                        principalTable: "QualificationTypeMaster",
                        principalColumn: "QualificationTypeMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualificationSpecializationMaster",
                schema: "HR",
                columns: table => new
                {
                    QualificationSpecializationMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationMasterId = table.Column<int>(type: "int", nullable: false),
                    SpecializationCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SpecializationName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationSpecializationMaster", x => x.QualificationSpecializationMasterId);
                    table.ForeignKey(
                        name: "FK_QualificationSpecializationMaster_QualificationMaster_QualificationMasterId",
                        column: x => x.QualificationMasterId,
                        principalSchema: "HR",
                        principalTable: "QualificationMaster",
                        principalColumn: "QualificationMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingEmployeeQualification",
                schema: "HR",
                columns: table => new
                {
                    OnboardingEmployeeQualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnboardingEmployeeId = table.Column<int>(type: "int", nullable: false),
                    QualificationMasterId = table.Column<int>(type: "int", nullable: false),
                    QualificationSpecializationMasterId = table.Column<int>(type: "int", nullable: true),
                    InstituteName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BoardOrUniversity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SpecializationDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PassingYear = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CGPA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CertificateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AttachmentFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AttachmentFilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsHighestQualification = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingEmployeeQualification", x => x.OnboardingEmployeeQualificationId);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeQualification_OnboardingEmployee_OnboardingEmployeeId",
                        column: x => x.OnboardingEmployeeId,
                        principalSchema: "HR",
                        principalTable: "OnboardingEmployee",
                        principalColumn: "OnboardingEmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeQualification_QualificationMaster_QualificationMasterId",
                        column: x => x.QualificationMasterId,
                        principalSchema: "HR",
                        principalTable: "QualificationMaster",
                        principalColumn: "QualificationMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnboardingEmployeeQualification_QualificationSpecializationMaster_QualificationSpecializationMasterId",
                        column: x => x.QualificationSpecializationMasterId,
                        principalSchema: "HR",
                        principalTable: "QualificationSpecializationMaster",
                        principalColumn: "QualificationSpecializationMasterId");
                });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.InsertData(
                schema: "HR",
                table: "IdentityDocumentMaster",
                columns: new[] { "IdentityDocumentMasterId", "CountryId", "CountryName", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "DocumentCode", "DocumentName", "HasExpiry", "IsActive", "IsMandatory", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, 1, null, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9335), null, 1, "AADHAAR", "Aadhaar Card", false, true, false, null, null },
                    { 2, 1, null, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9363), null, 2, "PAN", "PAN Card", false, true, false, null, null },
                    { 3, 1, null, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9365), null, 3, "PASSPORT", "Passport", true, true, false, null, null },
                    { 4, 1, null, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9367), null, 4, "DL", "Driving License", true, true, false, null, null },
                    { 5, null, null, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9369), null, 5, "NATIONALID", "National Identity Card", true, true, false, null, null },
                    { 6, null, null, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9373), null, 6, "WORKPERMIT", "Work Permit", true, true, false, null, null },
                    { 7, null, null, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9374), null, 7, "VISA", "Visa", true, true, false, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(427));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(510));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(663));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(704));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 3, 9, 11, 639, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.InsertData(
                schema: "HR",
                table: "QualificationTypeMaster",
                columns: new[] { "QualificationTypeMasterId", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IsActive", "ModifiedBy", "ModifiedOn", "QualificationTypeCode", "QualificationTypeName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9571), "Formal educational qualifications.", 1, true, null, null, "ACADEMIC", "Academic Qualification" },
                    { 2, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9576), "Professional certifications issued by recognized organizations.", 2, true, null, null, "CERTIFICATION", "Professional Certification" },
                    { 3, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9578), "Government or industry issued licenses.", 3, true, null, null, "LICENSE", "License" },
                    { 4, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9580), "Professional or internal training programs.", 4, true, null, null, "TRAINING", "Training" }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "QualificationMaster",
                columns: new[] { "QualificationMasterId", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "EducationLevel", "IsActive", "IsDefault", "IsProfessionalQualification", "ModifiedBy", "ModifiedOn", "QualificationCode", "QualificationName", "QualificationTypeMasterId", "RequiresExpiryDate", "RequiresRenewal" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9668), null, 1, "Secondary", true, true, false, null, null, "SSC", "Secondary School Certificate (SSC)", 1, false, false },
                    { 2, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9681), null, 2, "Higher Secondary", true, true, false, null, null, "HSC", "Higher Secondary Certificate (HSC)", 1, false, false },
                    { 3, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9684), null, 3, "Diploma", true, true, false, null, null, "DIPLOMA", "Diploma", 1, false, false },
                    { 4, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9685), null, 4, "Graduation", true, true, false, null, null, "BACHELOR", "Bachelor's Degree", 1, false, false },
                    { 5, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9687), null, 5, "Post Graduation", true, true, false, null, null, "MASTER", "Master's Degree", 1, false, false },
                    { 6, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9690), null, 6, "Doctorate", true, true, false, null, null, "PHD", "Doctor of Philosophy (PhD)", 1, false, false },
                    { 7, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9702), null, 7, "Certification", true, true, true, null, null, "AWS", "AWS Certification", 2, false, true },
                    { 8, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9721), null, 8, "Certification", true, true, true, null, null, "AZURE", "Microsoft Azure Certification", 2, false, true },
                    { 9, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9723), null, 9, "Certification", true, true, true, null, null, "PMP", "Project Management Professional (PMP)", 2, false, true },
                    { 10, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9726), null, 10, "Certification", true, true, true, null, null, "SCRUM", "Scrum Master Certification", 2, false, true },
                    { 11, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9728), null, 11, "License", true, true, false, null, null, "DL", "Driving License", 3, false, true },
                    { 12, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9730), null, 12, "Training", true, true, false, null, null, "SAFETY", "Safety Training", 4, false, false },
                    { 13, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9731), null, 13, "Training", true, true, false, null, null, "FIRSTAID", "First Aid Training", 4, false, true }
                });

            migrationBuilder.InsertData(
                schema: "HR",
                table: "QualificationSpecializationMaster",
                columns: new[] { "QualificationSpecializationMasterId", "CreatedBy", "CreatedOn", "Description", "DisplayOrder", "IsActive", "IsDefault", "ModifiedBy", "ModifiedOn", "QualificationMasterId", "SpecializationCode", "SpecializationName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9452), null, 1, true, true, null, null, 4, "CS", "Computer Science" },
                    { 2, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9460), null, 2, true, true, null, null, 4, "IT", "Information Technology" },
                    { 3, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9462), null, 3, true, true, null, null, 4, "MECH", "Mechanical Engineering" },
                    { 4, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9463), null, 4, true, true, null, null, 4, "CIVIL", "Civil Engineering" },
                    { 5, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9465), null, 5, true, true, null, null, 4, "ECE", "Electronics & Communication" },
                    { 6, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9467), null, 6, true, true, null, null, 4, "COMMERCE", "Commerce" },
                    { 7, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9469), null, 7, true, true, null, null, 5, "HR", "Human Resources" },
                    { 8, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9470), null, 8, true, true, null, null, 5, "FIN", "Finance" },
                    { 9, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9472), null, 9, true, true, null, null, 5, "MKT", "Marketing" },
                    { 10, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9474), null, 10, true, true, null, null, 5, "DS", "Data Science" },
                    { 11, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9476), null, 11, true, true, null, null, 5, "AI", "Artificial Intelligence" },
                    { 12, null, new DateTime(2026, 6, 26, 3, 9, 11, 638, DateTimeKind.Local).AddTicks(9477), null, 12, true, true, null, null, 6, "RESEARCH", "Research" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                schema: "HR",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocumentMaster_CountryId",
                schema: "HR",
                table: "IdentityDocumentMaster",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployee_EmployeeId",
                schema: "HR",
                table: "OnboardingEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployee_EmploymentTypeMasterId",
                schema: "HR",
                table: "OnboardingEmployee",
                column: "EmploymentTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployee_OnboardingStatusMasterId",
                schema: "HR",
                table: "OnboardingEmployee",
                column: "OnboardingStatusMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployee_OnboardingTemplateId",
                schema: "HR",
                table: "OnboardingEmployee",
                column: "OnboardingTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeActivity_OnboardingActivityMasterId",
                schema: "HR",
                table: "OnboardingEmployeeActivity",
                column: "OnboardingActivityMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeActivity_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeActivity",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeAddress_CityId",
                schema: "HR",
                table: "OnboardingEmployeeAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeAddress_CountryId",
                schema: "HR",
                table: "OnboardingEmployeeAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeAddress_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeAddress",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeBank_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeBank",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeDocument_OnboardingDocumentMasterId",
                schema: "HR",
                table: "OnboardingEmployeeDocument",
                column: "OnboardingDocumentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeDocument_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeDocument",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeEmergencyContact_CityId",
                schema: "HR",
                table: "OnboardingEmployeeEmergencyContact",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeEmergencyContact_CountryId",
                schema: "HR",
                table: "OnboardingEmployeeEmergencyContact",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeEmergencyContact_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeEmergencyContact",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeIdentity_IdentityDocumentMasterId",
                schema: "HR",
                table: "OnboardingEmployeeIdentity",
                column: "IdentityDocumentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeIdentity_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeIdentity",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePersonal_NationalityId",
                schema: "HR",
                table: "OnboardingEmployeePersonal",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePersonal_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeePersonal",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePolicyAcceptance_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeePolicyAcceptance",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeePolicyAcceptance_OnboardingPolicyMasterId",
                schema: "HR",
                table: "OnboardingEmployeePolicyAcceptance",
                column: "OnboardingPolicyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeQualification_OnboardingEmployeeId",
                schema: "HR",
                table: "OnboardingEmployeeQualification",
                column: "OnboardingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeQualification_QualificationMasterId",
                schema: "HR",
                table: "OnboardingEmployeeQualification",
                column: "QualificationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingEmployeeQualification_QualificationSpecializationMasterId",
                schema: "HR",
                table: "OnboardingEmployeeQualification",
                column: "QualificationSpecializationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationMaster_QualificationTypeMasterId",
                schema: "HR",
                table: "QualificationMaster",
                column: "QualificationTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationSpecializationMaster_QualificationMasterId",
                schema: "HR",
                table: "QualificationSpecializationMaster",
                column: "QualificationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                schema: "HR",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnboardingTemplate_Department_DepartmentId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "DepartmentId",
                principalSchema: "HR",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnboardingTemplate_Designation_DesignationId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "DesignationId",
                principalSchema: "HR",
                principalTable: "Designation",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnboardingTemplate_EmploymentTypeMaster_EmploymentTypeMasterId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "EmploymentTypeMasterId",
                principalSchema: "HR",
                principalTable: "EmploymentTypeMaster",
                principalColumn: "EmploymentTypeMasterId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                schema: "HR",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_OnboardingTemplate_Department_DepartmentId",
                schema: "HR",
                table: "OnboardingTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_OnboardingTemplate_Designation_DesignationId",
                schema: "HR",
                table: "OnboardingTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_OnboardingTemplate_EmploymentTypeMaster_EmploymentTypeMasterId",
                schema: "HR",
                table: "OnboardingTemplate");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeActivity",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeAddress",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeBank",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeDocument",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeEmergencyContact",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeIdentity",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeePersonal",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeePolicyAcceptance",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployeeQualification",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "IdentityDocumentMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "OnboardingEmployee",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "QualificationSpecializationMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "QualificationMaster",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "QualificationTypeMaster",
                schema: "HR");

            migrationBuilder.DropIndex(
                name: "IX_City_StateId",
                schema: "HR",
                table: "City");

            migrationBuilder.DropColumn(
                name: "StateId",
                schema: "HR",
                table: "City");

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7157));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "EmploymentTypeMaster",
                keyColumn: "EmploymentTypeMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7209));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityCategoryMaster",
                keyColumn: "OnboardingActivityCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8806));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8814));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingActivityMaster",
                keyColumn: "OnboardingActivityMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingDocumentCategoryMaster",
                keyColumn: "OnboardingDocumentCategoryMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyCategoryMaster",
                keyColumn: "OnboardingPolicyCategoryMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(8961));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingPolicyMaster",
                keyColumn: "OnboardingPolicyMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 591, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                schema: "HR",
                table: "OnboardingStatusMaster",
                keyColumn: "OnboardingStatusMasterId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2026, 6, 26, 1, 21, 25, 592, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.AddForeignKey(
                name: "FK_OnboardingTemplate_Department_DepartmentId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "DepartmentId",
                principalSchema: "HR",
                principalTable: "Department",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnboardingTemplate_Designation_DesignationId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "DesignationId",
                principalSchema: "HR",
                principalTable: "Designation",
                principalColumn: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnboardingTemplate_EmploymentTypeMaster_EmploymentTypeMasterId",
                schema: "HR",
                table: "OnboardingTemplate",
                column: "EmploymentTypeMasterId",
                principalSchema: "HR",
                principalTable: "EmploymentTypeMaster",
                principalColumn: "EmploymentTypeMasterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
