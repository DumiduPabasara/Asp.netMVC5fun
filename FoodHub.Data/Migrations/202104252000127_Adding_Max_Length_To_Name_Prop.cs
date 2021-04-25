namespace FoodHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_Max_Length_To_Name_Prop : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
        }
    }
}
