﻿// LICENSE PLACEHOLDER

using System.Collections.Generic;
using System.Data.SqlClient;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;

namespace OpenCBS.Manager
{
	/// <summary>
	/// Summary description for InstallmentTypeManagement.
	/// </summary>
	public class InstallmentTypeManager : Manager
	{
        public InstallmentTypeManager(User pUser) : base(pUser) {}

	    public InstallmentTypeManager(string testDB) : base(testDB) {}

		public int AddInstallmentType(InstallmentType installmentType)
		{
			const string q = @"INSERT INTO [InstallmentTypes]([name], [nb_of_days], [nb_of_months])
			                         VALUES(@name, @days, @months) SELECT SCOPE_IDENTITY()";

            using (SqlConnection conn = GetConnection())
            using (OctopusCommand c = new OctopusCommand(q, conn))
			{
			    SetInstallmentType(c, installmentType);
			    return int.Parse(c.ExecuteScalar().ToString());
			}
		}

        public void EditInstallmentType(InstallmentType installmentType)
        {
            const string q = @"UPDATE [InstallmentTypes] SET [name] = @name, [nb_of_days] = @days, [nb_of_months] = @months
                                     WHERE id = @id";

            using (SqlConnection conn = GetConnection())
            using (OctopusCommand c = new OctopusCommand(q, conn))
            {
                SetInstallmentType(c, installmentType);
                c.AddParam("@id", installmentType.Id);
                c.ExecuteNonQuery();
            }
        }

        public void DeleteInstallmentType(InstallmentType installmentType)
        {
            const string q = @"DELETE FROM [InstallmentTypes] WHERE id = @id";

            using (SqlConnection conn = GetConnection())
            using (OctopusCommand c = new OctopusCommand(q, conn))
            {
                c.AddParam("@id", installmentType.Id);
                c.ExecuteNonQuery();
            }
        }

	    private static void SetInstallmentType(OctopusCommand c, InstallmentType pInstallmentType)
	    {
	        c.AddParam("@name", pInstallmentType.Name);
	        c.AddParam("@days", pInstallmentType.NbOfDays);
	        c.AddParam("@months", pInstallmentType.NbOfMonths);
	    }

        public int NumberOfLinksToInstallmentType(InstallmentType installmentType)
        {
            const string q = @"SELECT COUNT(installment_type) FROM
                                    (
                                    SELECT installment_type FROM Credit
                                    UNION ALL
                                    SELECT installment_type FROM dbo.Packages
                                    UNION ALL
                                    SELECT installment_types_id AS [installment_type] FROM dbo.TermDepositProducts
                                    UNION ALL
                                    SELECT agio_fees_freq AS [installment_type] FROM dbo.SavingBookProducts
                                    UNION ALL
                                    SELECT management_fees_freq AS [installment_type] FROM dbo.SavingBookProducts
                                    ) AS T
                                    WHERE T.installment_type = @id";

            using (SqlConnection conn = GetConnection())
            using (OctopusCommand c = new OctopusCommand(q, conn))
            {
                c.AddParam("@id", installmentType.Id);
                return int.Parse(c.ExecuteScalar().ToString());
            }
        }

        public List<InstallmentType> SelectAllInstallmentTypes()
        {
            List<InstallmentType> list = new List<InstallmentType>();
			
            const string q = "SELECT * FROM InstallmentTypes ";

            using (SqlConnection conn = GetConnection())
            using (OctopusCommand c = new OctopusCommand(q, conn))
            using (OctopusReader r = c.ExecuteReader())
            {
                if (r == null || r.Empty) return list;
                while (r.Read())
                {
                    list.Add(GetInstallmentTypeFromReader(r));
                }
                return list;
            }
		}

        private static InstallmentType GetInstallmentTypeFromReader(OctopusReader r)
        {
            return new InstallmentType
                       {
                           Id = r.GetInt("id"),
                           Name = r.GetString("name"),
                           NbOfDays = r.GetInt("nb_of_days"),
                           NbOfMonths = r.GetInt("nb_of_months")
                       };
        }

	    /// <summary>
		/// InstallmentType Finder by id
		/// </summary>
        /// <param name="pInstallmentTypeId">id searched</param>
		/// <returns></returns>
		public InstallmentType SelectInstallmentType(int pInstallmentTypeId)
		{
			const string q = "SELECT * FROM InstallmentTypes WHERE id = @id";

            using (SqlConnection conn = GetConnection())
            using (OctopusCommand c = new OctopusCommand(q, conn))
			{
                c.AddParam("@id", pInstallmentTypeId);
                using (OctopusReader r = c.ExecuteReader())
                {
                    if (r == null || r.Empty) return null;
                    r.Read();
                    return GetInstallmentTypeFromReader(r);
                }
			}
		}

        public InstallmentType SelectInstallmentTypeByName(string name)
        {
			const string q = "SELECT * FROM InstallmentTypes WHERE name = @name";

            using (SqlConnection conn = GetConnection())
            using (OctopusCommand c = new OctopusCommand(q, conn))
			{
                c.AddParam("@name", name);

                using (OctopusReader r = c.ExecuteReader())
                {
                    if (r == null || r.Empty) return null;
                    r.Read();
                    return GetInstallmentTypeFromReader(r);
                }
			}
        }
	}
}