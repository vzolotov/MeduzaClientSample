using System.Runtime.Serialization;

namespace MeduzaClient.Models.Enum
{
    public enum DocumentType
    {
        Promo,
        Feature,
        News,
        Card,
        Fun,
        Topic,
        Gallery,
        [EnumMember(Value = "new_year_card")] NewYearCard,
        Rotation,
        Live
    }
}
