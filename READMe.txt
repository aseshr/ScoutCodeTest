Table structure-
[dbo].[Task_Master](
	[task_id] [int] IDENTITY(1,1) NOT NULL,
	[task_title] [varchar](50) NULL,
	[task_description] [varchar](200) NULL,
	[usr_id] [varchar](10) NULL,
	[task_entered] [datetime] NULL,
	[task_status] [char](1) NULL
)

For API-(ScoutAPI)
Step1-Please click on the visual studio solution file.
Step2-Once the visual studio opens the project,run it by clicking on the "IIS Express (Google Chrome)" on the top.

For UI-(ScoutsUI)
Step1-Please open command prompt and go to the folder where the "ScoutsUI" folder is saved.
Step2-Run the command - ng serve. 
Step3-Open any browser any go to http:localhost:4200
