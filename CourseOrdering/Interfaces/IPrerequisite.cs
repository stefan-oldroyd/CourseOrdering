namespace CourseOrdering
{
    public interface IPrerequisite
    {
        int course { get; set; }
        int prerequisite { get; set; }
    }
}