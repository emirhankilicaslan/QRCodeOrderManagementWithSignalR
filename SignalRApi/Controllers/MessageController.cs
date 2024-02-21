using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var list = _messageService.TGetListAll();
			return Ok(list);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message()
			{
				Mail = createMessageDto.Mail,
				MessageContent = createMessageDto.MessageContent,
				MessageSendDate = DateTime.Now,
				NameSurname = createMessageDto.NameSurname,
				Phone = createMessageDto.Phone,
				Status = false,
				Subject = createMessageDto.Subject
			};

			_messageService.TAdd(message);
			return Ok("Mesaj basarili bir sekilde gonderildi.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var entity = _messageService.TGetByID(id);
			_messageService.TDelete(entity);
			return Ok("Mesaj basarili bir sekilde silindi.");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message message = new Message()
			{
				Mail = updateMessageDto.Mail,
				MessageContent = updateMessageDto.MessageContent,
				MessageSendDate = updateMessageDto.MessageSendDate,
				NameSurname = updateMessageDto.NameSurname,
				Phone = updateMessageDto.Phone,
				Status = false,
				Subject = updateMessageDto.Subject,
				MessageID = updateMessageDto.MessageID
			};
			_messageService.TUpdate(message);
			return Ok("Mesaj basarili bir sekilde guncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var entity = _messageService.TGetByID(id);
			return Ok(entity);
		}
	}
}
