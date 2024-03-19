namespace _05_example_complex
{
    interface IRegistrarsOfficeInterface
    {
        string PhoneNumber { get; set; }
        string Name { get; set; }
        string NeptunCode { get; set; }
        Subject[] Subjects { get; set; }
        int SubjectCounter { get; }
    }
}