namespace JustGivingSDK.Contracts.Fundraising
{
    public class RememberedPersonReference
    { 
        /// <summary>
        /// Page creator relationship to remembered person
        /// Relationship Types:
        ///  HusbandWife,
        ///  Partner,
        ///  BrotherSister,
        ///  Parent,
        ///  SonDaughter,
        ///  Grandparent,
        ///  Grandchild,
        ///  OtherFamilyMember,
        ///  Friend,
        ///  WorkColleague,
        ///  Other,
        /// </summary>
        public string Relationship { get; set; }

        public RememberedPerson RememberedPerson { get; set; }
    }
}