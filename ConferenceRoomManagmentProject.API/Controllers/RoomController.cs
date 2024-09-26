using ConferenceRoomManagmentProject.Application.DTO;
using ConferenceRoomManagmentProject.Application.Interfaces;
using ConferenceRoomManagmentProject.Domain.IEntities;

using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomManagmentProject.API.Controllers;

[ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomsService _roomService;

        public RoomController(IRoomsService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// Adds a new conference room.
        /// </summary>
        [HttpPost("add-room")]
        public async Task<IActionResult> AddRoom([FromBody] RoomDTO roomDto)
        {
            if (roomDto == null)
            {
                return BadRequest("Invalid room data.");
            }

            try
            {
                var result = await _roomService.AddRoomAsync(roomDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the details of an existing conference room.
        /// </summary>
        [HttpPut("update-room/{roomId}")]
        public async Task<IActionResult> UpdateRoom(Guid roomId, [FromBody] RoomDTO roomDto)
        {
            if (roomDto == null)
            {
                return BadRequest("Invalid room data.");
            }

            try
            {
                var result = await _roomService.UpdateRoomAsync(roomId, roomDto);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Room not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an existing conference room.
        /// </summary>
        [HttpDelete("delete-room/{roomId}")]
        public async Task<IActionResult> DeleteRoom(Guid roomId)
        {
            try
            {
                await _roomService.DeleteRoomAsync(roomId);
                return Ok("Room deleted successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Room not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a list of available conference rooms.
        /// </summary>
        [HttpGet("available-rooms")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] DateTime date, [FromQuery] DateTime startTime, [FromQuery] DateTime endTime, [FromQuery] int capacity)
        {
            if (startTime >= endTime)
            {
                return BadRequest("Invalid time range.");
            }

            try
            {
                var availableRooms = await _roomService.GetAvailableRoomsAsync(date, startTime, endTime, capacity);
                return Ok(availableRooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // /// <summary>
        // /// Books a conference room.
        // /// </summary>
        // [HttpPost("book-room")]
        // public async Task<IActionResult> BookRoom([FromBody] BookingDTO bookingDto)
        // {
        //     if (bookingDto == null)
        //     {
        //         return BadRequest("Invalid booking data.");
        //     }
        //
        //     try
        //     {
        //         var result = await _roomService.BookRoomAsync(bookingDto);
        //         return Ok(result);
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"Internal server error: {ex.Message}");
        //     }
        // }
    }