namespace LojaDeCarros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vai3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cnpj = c.String(),
                        Linha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fornecedores");
        }
    }
}
