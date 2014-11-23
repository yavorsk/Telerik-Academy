namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardAccounts",
                c => new
                    {
                        CardAccountId = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(maxLength: 10),
                        CardPin = c.String(maxLength: 4),
                        CardCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CardAccountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CardAccounts");
        }
    }
}
