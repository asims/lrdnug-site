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
                        Name = c.String(nullable: false),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(),
                        MapUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PresentationTitle = c.String(nullable: false),
                        SpeakerName = c.String(nullable: false),
                        SpeakerBio = c.String(),
                        SpeakerTwitter = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        MonthYear = c.String(nullable: false),
                        SurveyURL = c.String(),
                        Location_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.Location_ID)
                .Index(t => t.Location_ID);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        URL = c.String(),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "Location_ID", "dbo.Locations");
            DropIndex("dbo.Meetings", new[] { "Location_ID" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Meetings");
            DropTable("dbo.Locations");
        }
    }
}
