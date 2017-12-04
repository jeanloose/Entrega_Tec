namespace LojaDeCarros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Idade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Idade", c => c.String());
        }
    }
}
