using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LimitLessLegal.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADAF_Branchess",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    cause_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADAF_Branchess", x => x.branch_id);
                });

            migrationBuilder.CreateTable(
                name: "ADAF_Carss",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_board = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_chassis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_motor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    license_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    license_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    license_examination_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trafiic_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_used = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    driver_insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licenseimg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADAF_Carss", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "ADAF_District_license_typess",
                columns: table => new
                {
                    district_license_types_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district_license_types_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    cause_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADAF_District_license_typess", x => x.district_license_types_id);
                });

            migrationBuilder.CreateTable(
                name: "Calender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID_Department = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID_Department);
                });

            migrationBuilder.CreateTable(
                name: "Jop",
                columns: table => new
                {
                    ID_jop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jop", x => x.ID_jop);
                });

            migrationBuilder.CreateTable(
                name: "Judgment",
                columns: table => new
                {
                    ID_Judgment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judgmentn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judgment", x => x.ID_Judgment);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Authorization_kindss",
                columns: table => new
                {
                    authorization_kinds_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authorization_kinds_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    authorization_kinds_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Authorization_kindss", x => x.authorization_kinds_id);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Causes",
                columns: table => new
                {
                    cause_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cause_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    cause_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Causes", x => x.cause_id);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Client_typess",
                columns: table => new
                {
                    client_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_type_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    client_type_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Client_typess", x => x.client_type_id);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Contractings",
                columns: table => new
                {
                    contracting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branchesID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Contracttybe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    writen_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contract_value = table.Column<float>(type: "real", nullable: false),
                    increase_perc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yearsnumber = table.Column<float>(type: "real", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    owner_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenant_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    leavetime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance_value = table.Column<float>(type: "real", nullable: false),
                    ID_TypeAnnualIncrease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contract_transfer_clause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licensenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    medicalarea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Licensedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagingDirector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contract_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    Conimg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cause_disable = table.Column<bool>(type: "bit", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom5 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom6 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom7 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startfrom8 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Montvalue8 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Contractings", x => x.contracting_id);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Courts",
                columns: table => new
                {
                    court_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    court_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    court_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Courts", x => x.court_id);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Lawsuit_Statuss",
                columns: table => new
                {
                    lawsuit_Status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lawsuit_Status_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    lawsuit_Status_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Lawsuit_Statuss", x => x.lawsuit_Status_id);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Litigants",
                columns: table => new
                {
                    litigant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    litigant_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    litigant_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Litigants", x => x.litigant_id);
                });

            migrationBuilder.CreateTable(
                name: "Permission_groups",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_groups", x => x.permission_id);
                });

            migrationBuilder.CreateTable(
                name: "branchleaves",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch = table.Column<int>(type: "int", nullable: false),
                    branch_idا = table.Column<int>(type: "int", nullable: true),
                    Company_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_licens_holder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_responsible_manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_being_hired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nationaid_owner_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationaid_manager_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_owner_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_manager_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    license_number_owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    License_number_Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    license_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    medical_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branchleaves", x => x.id);
                    table.ForeignKey(
                        name: "FK_branchleaves_ADAF_Branchess_branch_idا",
                        column: x => x.branch_idا,
                        principalTable: "ADAF_Branchess",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Central",
                columns: table => new
                {
                    ID_central = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    LandlineNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandlineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffiliateCentral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternetBillValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subscriptiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thebunch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectTheSituation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromCts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToCts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Central", x => x.ID_central);
                    table.ForeignKey(
                        name: "FK_Central_ADAF_Branchess_branch_id",
                        column: x => x.branch_id,
                        principalTable: "ADAF_Branchess",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ADAF_District_licenses",
                columns: table => new
                {
                    district_license_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    district_license_type_id = table.Column<int>(type: "int", nullable: false),
                    district_license_types_id = table.Column<int>(type: "int", nullable: true),
                    license_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    license_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    district_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    license_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADAF_District_licenses", x => x.district_license_id);
                    table.ForeignKey(
                        name: "FK_ADAF_District_licenses_ADAF_Branchess_branch_id",
                        column: x => x.branch_id,
                        principalTable: "ADAF_Branchess",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ADAF_District_licenses_ADAF_District_license_typess_district_license_types_id",
                        column: x => x.district_license_types_id,
                        principalTable: "ADAF_District_license_typess",
                        principalColumn: "district_license_types_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "investigation",
                columns: table => new
                {
                    ID_investigation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Noofcomplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employeename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employeeid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_jop = table.Column<int>(type: "int", nullable: false),
                    NatureComplaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Invstdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Decisionafterinvst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Invstnotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Department = table.Column<int>(type: "int", nullable: false),
                    Investigator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idinvist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Invimage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investigation", x => x.ID_investigation);
                    table.ForeignKey(
                        name: "FK_investigation_Department_ID_Department",
                        column: x => x.ID_Department,
                        principalTable: "Department",
                        principalColumn: "ID_Department",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_investigation_Jop_ID_jop",
                        column: x => x.ID_jop,
                        principalTable: "Jop",
                        principalColumn: "ID_jop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Authorizations",
                columns: table => new
                {
                    authorization_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authorization_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorization_source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorization_character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorization_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorization_kinds_id = table.Column<int>(type: "int", nullable: false),
                    authorization_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    authorization_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorization_disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Authorizations", x => x.authorization_id);
                    table.ForeignKey(
                        name: "FK_LGL_Authorizations_LGL_Authorization_kindss_authorization_kinds_id",
                        column: x => x.authorization_kinds_id,
                        principalTable: "LGL_Authorization_kindss",
                        principalColumn: "authorization_kinds_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Clientss",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    client_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    associate_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ph1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ph2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    client_type_id = table.Column<int>(type: "int", nullable: false),
                    client_disable = table.Column<bool>(type: "bit", nullable: false),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Clientss", x => x.client_id);
                    table.ForeignKey(
                        name: "FK_LGL_Clientss_LGL_Client_typess_client_type_id",
                        column: x => x.client_type_id,
                        principalTable: "LGL_Client_typess",
                        principalColumn: "client_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission_pagess",
                columns: table => new
                {
                    page_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    page_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission_pagess", x => x.page_id);
                    table.ForeignKey(
                        name: "FK_Permission_pagess_Permission_groups_permission_id",
                        column: x => x.permission_id,
                        principalTable: "Permission_groups",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Userss",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userpassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    useremail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_add = table.Column<DateTime>(type: "datetime2", nullable: false),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userss", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Userss_Permission_groups_permission_id",
                        column: x => x.permission_id,
                        principalTable: "Permission_groups",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Lawsuits",
                columns: table => new
                {
                    lawsuit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lawsuit_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cause_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cause_id = table.Column<int>(type: "int", nullable: false),
                    lawsuit_circle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    court_id = table.Column<int>(type: "int", nullable: false),
                    sitting_date_first = table.Column<DateTime>(type: "datetime2", nullable: false),
                    litigant_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    client_type_id = table.Column<int>(type: "int", nullable: false),
                    LGL_Client_types = table.Column<int>(type: "int", nullable: true),
                    ID_Judgment = table.Column<int>(type: "int", nullable: false),
                    PronouncingJudgment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lawsuit_degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trapping_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lawsuit_Status_id = table.Column<int>(type: "int", nullable: false),
                    associate_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lawsuit_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    lawsuitfile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Lawsuits", x => x.lawsuit_id);
                    table.ForeignKey(
                        name: "FK_LGL_Lawsuits_Judgment_ID_Judgment",
                        column: x => x.ID_Judgment,
                        principalTable: "Judgment",
                        principalColumn: "ID_Judgment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LGL_Lawsuits_LGL_Causes_cause_id",
                        column: x => x.cause_id,
                        principalTable: "LGL_Causes",
                        principalColumn: "cause_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LGL_Lawsuits_LGL_Client_typess_LGL_Client_types",
                        column: x => x.LGL_Client_types,
                        principalTable: "LGL_Client_typess",
                        principalColumn: "client_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LGL_Lawsuits_LGL_Clientss_client_id",
                        column: x => x.client_id,
                        principalTable: "LGL_Clientss",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LGL_Lawsuits_LGL_Courts_court_id",
                        column: x => x.court_id,
                        principalTable: "LGL_Courts",
                        principalColumn: "court_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LGL_Lawsuits_LGL_Lawsuit_Statuss_lawsuit_Status_id",
                        column: x => x.lawsuit_Status_id,
                        principalTable: "LGL_Lawsuit_Statuss",
                        principalColumn: "lawsuit_Status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LGL_Lawsuits_LGL_Litigants_litigant_id",
                        column: x => x.litigant_id,
                        principalTable: "LGL_Litigants",
                        principalColumn: "litigant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LGL_lawsuit_filess",
                columns: table => new
                {
                    lawsuit_files_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lawsuit_id = table.Column<int>(type: "int", nullable: false),
                    lawsuit_files_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_lawsuit_filess", x => x.lawsuit_files_id);
                    table.ForeignKey(
                        name: "FK_LGL_lawsuit_filess_LGL_Lawsuits_lawsuit_id",
                        column: x => x.lawsuit_id,
                        principalTable: "LGL_Lawsuits",
                        principalColumn: "lawsuit_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LGL_Sessionss",
                columns: table => new
                {
                    sessions_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lawsuit_id = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    court_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delay_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    litigant_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    session_next_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_user = table.Column<int>(type: "int", nullable: false),
                    last_update_user = table.Column<int>(type: "int", nullable: false),
                    finished = table.Column<bool>(type: "bit", nullable: false),
                    rollno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    session_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    decision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requests = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGL_Sessionss", x => x.sessions_id);
                    table.ForeignKey(
                        name: "FK_LGL_Sessionss_LGL_Lawsuits_lawsuit_id",
                        column: x => x.lawsuit_id,
                        principalTable: "LGL_Lawsuits",
                        principalColumn: "lawsuit_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADAF_District_licenses_branch_id",
                table: "ADAF_District_licenses",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_ADAF_District_licenses_district_license_types_id",
                table: "ADAF_District_licenses",
                column: "district_license_types_id");

            migrationBuilder.CreateIndex(
                name: "IX_branchleaves_branch_idا",
                table: "branchleaves",
                column: "branch_idا");

            migrationBuilder.CreateIndex(
                name: "IX_Central_branch_id",
                table: "Central",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_investigation_ID_Department",
                table: "investigation",
                column: "ID_Department");

            migrationBuilder.CreateIndex(
                name: "IX_investigation_ID_jop",
                table: "investigation",
                column: "ID_jop");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Authorizations_authorization_kinds_id",
                table: "LGL_Authorizations",
                column: "authorization_kinds_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Clientss_client_type_id",
                table: "LGL_Clientss",
                column: "client_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_lawsuit_filess_lawsuit_id",
                table: "LGL_lawsuit_filess",
                column: "lawsuit_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Lawsuits_cause_id",
                table: "LGL_Lawsuits",
                column: "cause_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Lawsuits_client_id",
                table: "LGL_Lawsuits",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Lawsuits_court_id",
                table: "LGL_Lawsuits",
                column: "court_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Lawsuits_ID_Judgment",
                table: "LGL_Lawsuits",
                column: "ID_Judgment");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Lawsuits_lawsuit_Status_id",
                table: "LGL_Lawsuits",
                column: "lawsuit_Status_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Lawsuits_LGL_Client_types",
                table: "LGL_Lawsuits",
                column: "LGL_Client_types");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Lawsuits_litigant_id",
                table: "LGL_Lawsuits",
                column: "litigant_id");

            migrationBuilder.CreateIndex(
                name: "IX_LGL_Sessionss_lawsuit_id",
                table: "LGL_Sessionss",
                column: "lawsuit_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_pagess_permission_id",
                table: "Permission_pagess",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_Userss_permission_id",
                table: "Userss",
                column: "permission_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADAF_Carss");

            migrationBuilder.DropTable(
                name: "ADAF_District_licenses");

            migrationBuilder.DropTable(
                name: "branchleaves");

            migrationBuilder.DropTable(
                name: "Calender");

            migrationBuilder.DropTable(
                name: "Central");

            migrationBuilder.DropTable(
                name: "investigation");

            migrationBuilder.DropTable(
                name: "LGL_Authorizations");

            migrationBuilder.DropTable(
                name: "LGL_Contractings");

            migrationBuilder.DropTable(
                name: "LGL_lawsuit_filess");

            migrationBuilder.DropTable(
                name: "LGL_Sessionss");

            migrationBuilder.DropTable(
                name: "Permission_pagess");

            migrationBuilder.DropTable(
                name: "Userss");

            migrationBuilder.DropTable(
                name: "ADAF_District_license_typess");

            migrationBuilder.DropTable(
                name: "ADAF_Branchess");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Jop");

            migrationBuilder.DropTable(
                name: "LGL_Authorization_kindss");

            migrationBuilder.DropTable(
                name: "LGL_Lawsuits");

            migrationBuilder.DropTable(
                name: "Permission_groups");

            migrationBuilder.DropTable(
                name: "Judgment");

            migrationBuilder.DropTable(
                name: "LGL_Causes");

            migrationBuilder.DropTable(
                name: "LGL_Clientss");

            migrationBuilder.DropTable(
                name: "LGL_Courts");

            migrationBuilder.DropTable(
                name: "LGL_Lawsuit_Statuss");

            migrationBuilder.DropTable(
                name: "LGL_Litigants");

            migrationBuilder.DropTable(
                name: "LGL_Client_typess");
        }
    }
}
