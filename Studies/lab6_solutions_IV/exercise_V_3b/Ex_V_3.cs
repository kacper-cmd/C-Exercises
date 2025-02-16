
namespace group_person
{
    partial class Group
    {
        public static bool operator >(Group g1, Group g2)
        {
            return g1.nonEmptyPlacesCount() > g2.nonEmptyPlacesCount();
        }
        public static bool operator <(Group g1, Group g2)
        {
            return g1.nonEmptyPlacesCount() < g2.nonEmptyPlacesCount();
        }
    }
}
