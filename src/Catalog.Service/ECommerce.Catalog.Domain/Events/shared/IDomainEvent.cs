using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Events.shared;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
