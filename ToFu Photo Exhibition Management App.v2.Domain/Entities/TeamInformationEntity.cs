using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Entities
{
	public class TeamInformationEntity
	{
		public TeamInformationEntity(int id,int teamId,int manufacturerId,int categoryId,string team,string manufacturer,string category)
		{
			Id = new Id(id);
			TeamId = new TeamId(teamId);
			ManufacturerId = new ManufacturerId(manufacturerId);
			CategoryId = new CategoryId(categoryId);
			Team = new Team(team);
			Manufacturer = new Manufacturer(manufacturer);
			Category = new Category(category);
		}
		public Id Id { get; }
		public TeamId TeamId { get; }
		public ManufacturerId ManufacturerId { get; }
		public CategoryId CategoryId { get; }
		public Team Team { get; }
		public Manufacturer Manufacturer { get; }
		public Category Category { get; }
	}
}
