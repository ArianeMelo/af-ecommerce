using AF_ECommerce.Test.Fixture;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AF_ECommerce.Test.Collections
{
    [CollectionDefinition(nameof(ClienteApplicationCollection))]
    public class ClienteApplicationCollection
        : ICollectionFixture<ClienteApplicationFixture>
    {
    }
}
