namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionBd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "DateOfTransaction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "DateOfTransaction", c => c.DateTime(nullable: false));
        }
    }
}
