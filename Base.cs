namespace UserManagement
{
    public class Base
    {
        
            public string Status { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime UpdatedOn { get; set; }

            public int createdBy { get; set; }
            public int updatedBy { get; set; }

        
    }
}
