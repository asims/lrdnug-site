namespace LRDNUG.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Street1 = c.String(maxLength: 4000),
                        Street2 = c.String(maxLength: 4000),
                        City = c.String(nullable: false, maxLength: 4000),
                        State = c.String(nullable: false, maxLength: 4000),
                        Zip = c.String(maxLength: 4000),
                        MapUrl = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        URL = c.String(maxLength: 4000),
                        LogoUrl = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PresentationTitle = c.String(nullable: false, maxLength: 4000),
                        SpeakerName = c.String(nullable: false, maxLength: 4000),
                        SpeakerBio = c.String(maxLength: 4000),
                        SpeakerTwitter = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.String(maxLength: 4000),
                        MonthYear = c.String(nullable: false, maxLength: 4000),
                        SurveyURL = c.String(maxLength: 4000),
                        Location_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.Location_ID)
                .Index(t => t.Location_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Meetings", new[] { "Location_ID" });
            DropForeignKey("dbo.Meetings", "Location_ID", "dbo.Locations");
            DropTable("dbo.Meetings");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Locations");
        }
    }
}
