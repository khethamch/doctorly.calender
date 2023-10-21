namespace doctorly.calender.SqlQueries
{
    public static class AttendeeQuery
    {
        public const string ConfirmAttendingEvent = @"UPDATE [dbo].[Attendees]
   SET [IsAttending] = @IsAttending
 WHERE [Id] = @EventId

IF NOT EXISTS (SELECT [Id] FROM [dbo].[EventAttendees] WHERE [EventId] = @EventId AND [AttendeeId] = @AttendeeId)
BEGIN
INSERT INTO [dbo].[EventAttendees]
           ([EventId]
           ,[AttendeeId])
     VALUES
           (@EventId
           ,@AttendeeId)
END";

        public const string CreateAttendee = @"IF NOT EXISTS (SELECT [Id] FROM [dbo].[Attendees] WHERE [Email] = @Email)
BEGIN
	INSERT INTO [dbo].[Attendees]
           ([Name]
           ,[Email]
           ,[Address]
           ,[IsAttending])
     VALUES
           (@Name
           ,@Email
           ,@Address
           ,0)
END";
    }
}
