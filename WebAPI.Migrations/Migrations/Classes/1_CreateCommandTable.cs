using System.IO;
using System.Reflection;

namespace WebAPI.Migrations.Migrations.Classes
{
    using FluentMigrator;
    
    [Migration(1, "Add command info table")]
    public class CreateCommandTable: AbstractMigration
    {
        private readonly string scriptName;
        public CreateCommandTable()
        {
            this.scriptName = "1_CreateCommandTable.sql";
        }
        public override void Up()
        {
            string filePath = this.GetEmbeddedUpScriptPath();
            this.ExecuteSqlStatementFromFile(filePath);
        }

        public override void Down()
        {
            string filePath = this.GetEmbeddedDownScriptPath();
            this.ExecuteSqlStatementFromFile(filePath);
        }
        
        private string GetEmbeddedUpScriptPath()
        {
            return $"Migrations/UpScripts/{this.scriptName}";
        }

        private string GetEmbeddedDownScriptPath()
        {
            return $"Migrations/DownScripts/{this.scriptName}";
        }
        
        protected void ExecuteSqlStatementFromFile(string filePath)
        {
            string sqlStatement = this.GetEmbeddedResource(filePath);
            this.Execute.Sql(sqlStatement);
        }

        private string GetEmbeddedResource(string resourceName)
        {
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            resourceName = this.FormatResourceName(assembly, resourceName);

            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                    return null;

                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        
        private string FormatResourceName(Assembly assembly, string resourceName)
        {
            return assembly.GetName().Name + "." + resourceName.Replace(" ", "_")
                .Replace("\\", ".")
                .Replace("/", ".");
        }
    }
}