using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var list = _menuTableService.TGetListAll();
			return Ok(list);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable menuTable = new MenuTable()
			{
				Name = createMenuTableDto.Name,
				Status = false
			};

			_menuTableService.TAdd(menuTable);
			return Ok("Masa basarili bir sekilde eklendi.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var entity = _menuTableService.TGetByID(id);
			_menuTableService.TDelete(entity);
			return Ok("Masa basarili bir sekilde silindi.");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable menuTable = new MenuTable()
			{
				Name = updateMenuTableDto.Name,
				Status = false,
				MenuTableID = updateMenuTableDto.MenuTableID
			};
			_menuTableService.TUpdate(menuTable);
			return Ok("Masa bilgileri basarili bir sekilde guncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var entity = _menuTableService.TGetByID(id);
			return Ok(entity);
		}
	}
}
