 using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mthembu_Funeral_Policy_App.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mthembu_Funeral_Policy_App.Models
    {
        // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
        public class ApplicationUser : IdentityUser
        {
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

                    public DbSet<Transaction> Transactions { get; set; }
                   public DbSet<tlbClient> tlbClients { get; set; }
                     public DbSet<tlbMember> tlbMembers { get; set; }
                        public  DbSet<tlbClaim> tlbClaims { get; set; }
                        public DbSet<tblFile> tblFiles { get; set; }
                    public DbSet<tlbMessage> tlbMessages { get; set; }
                    public DbSet<tlbPayment> tlbPayments { get; set; }
                     public DbSet<tlbPolicy> tlbPolicies { get; set; }
                    public DbSet<tlbSpouse> tlbSpouses { get; set; }
                     public DbSet<tlbBeneficiary> tlbBeneficiaries { get; set; }
                     public DbSet<tlbAccount> tlbAccounts { get; set; }
                  
        
    }
    }
