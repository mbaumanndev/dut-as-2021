using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MBaumann.IUT.Forum.Ui.Migrations
{
    public partial class CategorieTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.IsSqlServer())
            {
                migrationBuilder.Sql(@"
CREATE OR ALTER TRIGGER [dbo].[trig_CategorieUpdate] -- Nom du trigger
    ON [dbo].[Categorie] -- On l'assigne à une table
    AFTER UPDATE -- Après quel événement on déclenche
AS
BEGIN
    SET NOCOUNT ON -- Désactive le comptage

    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN; -- Eviter déclenchement en cascade

    DECLARE @CatId SMALLINT
    DECLARE @NbItems INT

    SELECT @NbItems = COUNT(*) FROM INSERTED

    IF @NbItems > 1
    BEGIN
        DECLARE curs CURSOR FORM SELECT [Id] FROM INSERTED
        OPEN curs

        FETCH NEXT FROM curs INTO @CatId
        WHILE (@@FETCH_STATUS = 0)
        BEGIN
            UPDATE [dbo].[Categorie]
            SET [Modification] = GETUTCDATE()
            WHERE [Id] = @CatId

            FETCH NEXT FROM curs INTO @CatId
        END

        CLOSE curs
        DEALLOCATE curs
    END
    ELSE
    BEGIN
        SELECT TOP 1 @CatId = [Id] FROM INSERTED -- On récupère l'ID depuis une ""table""

        UPDATE[dbo].[Categorie]
        SET[Modification] = GETUTCDATE()
        WHERE[Id] = @CatId
    END
END
");
            }
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.IsSqlServer())
            {
                migrationBuilder.Sql(@"
DROP TRIGGER IF EXISTS [dbo].[trig_CategorieUpdate]
");
            }
        }
    }
}
