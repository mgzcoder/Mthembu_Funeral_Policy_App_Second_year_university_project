using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mthembu_Funeral_Policy_App.Models
{
    public class Qoutation
    {
        [Required]
        [Range(1,13)]
        [Display(Name ="Number of members")]
        public int NumMembers { get; set; }
        [Required]
        public string CoverType { get; set; }
       
        public double TotalPrice { get; set; }




        public double ParentsCalc()
        {

            double TotalPrice = 0;
           
            
                if (CoverType == "Bronze")
                {
                    TotalPrice = NumMembers * 150 * 0.05 + 150;
                }
                else if (CoverType == "Silver")
                {
                    TotalPrice = NumMembers * 200 * 0.05 + 200;
                }
                else if (CoverType == "Gold")
                {
                    TotalPrice = NumMembers * 300 * 0.05 + 300;

                }

            
            return TotalPrice;

        }

        public double Over80Calc()
        {

            double TotalPrice = 0;
            
            
                if (CoverType == "Bronze")
                {
                    TotalPrice = NumMembers * 350 * 0.05 + 350;
                }
                else if (CoverType == "Silver")
                {
                    TotalPrice = NumMembers * 400 * 0.05 + 400;
                }
                else if (CoverType == "Gold")
                {
                    TotalPrice = NumMembers * 500 * 0.05 + 500;

                }

            
            return TotalPrice;

        }



        public double FamilyCovCalc()
        {

            double TotalPrice = 0;
         
            
                if (CoverType == "Bronze")
                {
                    TotalPrice = NumMembers * 350 * 0.05 + 350;
                }
                else if (CoverType == "Silver")
                {
                    TotalPrice = NumMembers * 400 * 0.05 + 400;
                }
                else if (CoverType == "Gold")
                {
                    TotalPrice = NumMembers * 450 * 0.05 + 450;

                }

            
            return TotalPrice;

        }

        public double ExtendedCalc()
        {

            double TotalPrice = 0;
           
            
                if (CoverType == "Bronze")
                {
                    TotalPrice = NumMembers * 250 * 0.05 + 250;
                }
                else if (CoverType == "Silver")
                {
                    TotalPrice = NumMembers * 300 * 0.05 + 300;
                }
                else if (CoverType == "Gold")
                {
                    TotalPrice = NumMembers * 400 * 0.05 + 400;

                }

            
            return TotalPrice;

        }



        public double NoPeriodCalc()
        {

            double TotalPrice = 0;
            
            
                if (CoverType == "Bronze")
                {
                    TotalPrice = NumMembers * 350 * 0.05 + 350;
                }
                else if (CoverType == "Silver")
                {
                    TotalPrice = NumMembers * 400 * 0.05 + 400;
                }
                else if (CoverType == "Gold")
                {
                    TotalPrice = NumMembers * 450 * 0.05 + 450;

                }

            
            return TotalPrice;

        }
    }
}