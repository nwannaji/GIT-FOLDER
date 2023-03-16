using DataAccessLibrary;
using DataAccessLibrary.DeviceData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        //private List<DeviceModel> devices = new List<DeviceModel>();
        private readonly IAccessControllerDevicesData _devices;

        public DeviceController(IAccessControllerDevicesData devices)
        {
            this._devices = devices;
        }
        [HttpGet]
        private async Task<ActionResult<DeviceModel>> GetDevice()
        {
            try
            {
                return Ok(await _devices.GetDevices());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Error retrieving devices from database");
            }

        }
        [HttpGet("{id:int}")]
        private async Task<ActionResult<DeviceModel>> GetDeviceId(int Id)
        {
            try
            {
                var result = await _devices.GetDeviceById(Id);
                if(result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Error retrieving device serial number from database");
            }

        }

    }
}
