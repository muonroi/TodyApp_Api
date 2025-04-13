



#nullable disable

namespace RemindApp.Data.Persistence.Migrations;

/// <inheritdoc />
public partial class InitDb : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "MLanguages",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                DisplayName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Icon = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MLanguages", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "MPermissions",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                IsGranted = table.Column<bool>(type: "boolean", nullable: false),
                Discriminator = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MPermissions", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "MRefreshTokens",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                Token = table.Column<string>(type: "text", nullable: false),
                TokenValidityKey = table.Column<string>(type: "text", nullable: false),
                ExpiredDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                RevokedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastUsedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                ReasonRevoked = table.Column<string>(type: "text", nullable: false),
                IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MRefreshTokens", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "MRolePermissions",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MRolePermissions", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "MRoles",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                DisplayName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                NormalizedName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                IsStatic = table.Column<bool>(type: "boolean", nullable: false),
                IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                ConcurrencyStamp = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MRoles", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "MUserLoginAttempts",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                UserNameOrEmailAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                ClientIpAddress = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                ClientName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                BrowserInfo = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                Result = table.Column<byte>(type: "smallint", nullable: false),
                AttemptTime = table.Column<int>(type: "integer", nullable: false),
                LockTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MUserLoginAttempts", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "MUserRoles",
            columns: table => new
            {
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MUserRoles", x => new { x.UserId, x.RoleId });
            });

        _ = migrationBuilder.CreateTable(
            name: "MUsers",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                EmailAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Surname = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                PasswordResetCode = table.Column<string>(type: "text", nullable: true),
                PhoneNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                IsPhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                SecurityStamp = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                IsTwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                IsActive = table.Column<bool>(type: "boolean", nullable: false),
                NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                NormalizedEmailAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                ConcurrencyStamp = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                Salt = table.Column<string>(type: "text", nullable: true),
                ProfilePictureId = table.Column<int>(type: "integer", nullable: true),
                ShouldChangePasswordOnNextLogin = table.Column<bool>(type: "boolean", nullable: false),
                SignInTokenExpireTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MUsers", x => x.Id);
            });

        _ = migrationBuilder.CreateTable(
            name: "MUserTokens",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                UserId = table.Column<long>(type: "bigint", nullable: false),
                LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Value = table.Column<string>(type: "text", nullable: false),
                ExpireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MUserTokens", x => x.Id);
            });

        _ = migrationBuilder.CreateIndex(
            name: "IX_MLanguages_Name",
            table: "MLanguages",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_MPermissions_Name",
            table: "MPermissions",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_MRoles_Name",
            table: "MRoles",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_MUserLoginAttempt_UserNameOrEmailAddress",
            table: "MUserLoginAttempts",
            column: "UserNameOrEmailAddress");

        _ = migrationBuilder.CreateIndex(
            name: "IX_MUser_UserName",
            table: "MUsers",
            column: "UserName",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_MUserToken_LoginProvider",
            table: "MUserTokens",
            column: "LoginProvider");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "MLanguages");

        _ = migrationBuilder.DropTable(
            name: "MPermissions");

        _ = migrationBuilder.DropTable(
            name: "MRefreshTokens");

        _ = migrationBuilder.DropTable(
            name: "MRolePermissions");

        _ = migrationBuilder.DropTable(
            name: "MRoles");

        _ = migrationBuilder.DropTable(
            name: "MUserLoginAttempts");

        _ = migrationBuilder.DropTable(
            name: "MUserRoles");

        _ = migrationBuilder.DropTable(
            name: "MUsers");

        _ = migrationBuilder.DropTable(
            name: "MUserTokens");
    }
}
