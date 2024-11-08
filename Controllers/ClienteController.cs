using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private static List<Cliente> clientes = new List<Cliente>();

    [HttpGet]
    public ActionResult<List<Cliente>> GetAll()
    {
        return clientes;
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> GetById(int id)
    {
        Cliente clienteEncontrado = null;
        foreach(var cliente in clientes)
        {
            if(cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }
        if(clienteEncontrado == null)
        {
            return NotFound();
        }
        return clienteEncontrado;
    }

    [HttpPost]
    public ActionResult Post(Cliente cliente)
    {
        clientes.Add(cliente);
        return Created();
    }
    
    [HttpPut("{id}")]
    public ActionResult Put(int id, Cliente clienteAtualizado)
    {
        Cliente clienteEncontrado = null;
        foreach(var cliente in clientes)
        {
            if(cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }
        if(clienteEncontrado == null)
        {
            return NotFound();
        }
        clienteEncontrado.Nome = clienteAtualizado.Nome;
        clienteEncontrado.Contato = clienteAtualizado.Contato;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Cliente clienteEncontrado = null;
        foreach(var cliente in clientes)
        {
            if(cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }
        if(clienteEncontrado == null)
        {
            return NotFound();
        }
        clientes.Remove(clienteEncontrado);
        return NoContent();
    }
}