using Dominio;
using Repository;



using (var context = new SchoolContext())
{
    var grado = new Grade()
    {
        GradeId = 0,
        GradeName = "primero"
    };

    var student = new Student
    {
        FirstName = "Juan",
        LastName = "Perez",
        Grade = grado
    };
    context.Add(grado);
    context.Add(student);
    context.SaveChanges();
}

