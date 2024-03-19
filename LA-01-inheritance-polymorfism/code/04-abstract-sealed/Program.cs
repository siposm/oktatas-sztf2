namespace _04_abstract_sealed
{
    abstract class GameCharacterModel { }

    abstract class PersonModel : GameCharacterModel { }
    
    class EnemyModel : GameCharacterModel { }

    class StudentModel : PersonModel { }

    class TeacherModel : PersonModel { }

    sealed class MathsTeacherModel : TeacherModel { }

    //class XY : MathsTeacherModel { }
    // Can't create descendant class from a sealed base class.


    internal class Program
    {
        static void Main(string[] args)
        {
            //GameCharacterModel gcm = new GameCharacterModel();
            // Can't create instance from abstract class.

            //PersonModel pm = new PersonModel();
            // Same.

            StudentModel sm = new StudentModel();
            TeacherModel tm = new TeacherModel();

            // abstract => can't create object out of it
            // sealed => can't create descendant class out of it
        }
    }
}