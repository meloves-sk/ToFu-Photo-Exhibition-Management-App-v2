using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Entities
{
	public class RoundEntity
	{
		public RoundEntity(int id, string name)
		{
			Id = new Id(id);
			Name = new Name(name);
		}
		public Id Id { get; }
		public Name Name { get; }
	}
}
