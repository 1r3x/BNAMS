using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Entities.ViewModels
{
    public class ProfileAddressViewModel
    {

        public int Army_id { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> Army_no { get; set; }
        public string Army_name { get; set; }
        public string AI { get; set; }
        public string AI13 { get; set; }
        public Nullable<int> Rank_id { get; set; }
        public Nullable<int> Trade_id { get; set; }
        public string NedCat { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> Enr_date { get; set; }
        public Nullable<System.DateTime> DoA { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> blood_gp { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<int> religion { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> GarrisonId { get; set; }
        public string Photo { get; set; }
        public Nullable<int> RecordStatus { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDateTime { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public Nullable<int> VerifyBy { get; set; }
        public Nullable<System.DateTime> VerifyDateTime { get; set; }
        public Nullable<int> BJO_no { get; set; }
        public Nullable<System.DateTime> SOD { get; set; }
        public Nullable<int> Previous_home_district_id { get; set; }
        public Nullable<int> Home_district_id { get; set; }
        public Nullable<int> Basic_trade_id { get; set; }
        public Nullable<int> village { get; set; }
        public Nullable<int> post_office { get; set; }
        public Nullable<int> post_code { get; set; }
        public Nullable<int> police_station { get; set; }
        public Nullable<int> upazila { get; set; }
        public Nullable<System.DateTime> custom_enr_date { get; set; }
        public string rmk { get; set; }

        //Address
        public int AddressId { get; set; }
        public int Army_idAddress { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> UpazilaId { get; set; }
        public Nullable<int> PoliceStationId { get; set; }
        public Nullable<int> PostOfficeId { get; set; }
        public Nullable<int> PostCode { get; set; }
        public Nullable<int> VillageId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<int> RecordStatusAddress { get; set; }
        public Nullable<int> EntryByAddress { get; set; }
        public Nullable<System.DateTime> EntryDateTimeAddress { get; set; }
        public Nullable<bool> IsVerifiedAddress { get; set; }
        public Nullable<int> VerifyByAddress { get; set; }
        public Nullable<System.DateTime> VerifyDateTimeAddress { get; set; }

    }
}
