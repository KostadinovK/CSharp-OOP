using System;
using NUnit.Framework;


namespace StorageMester.BusinessLogic.Tests
{
    using StorageMaster.Core;

    [TestFixture]
    public class StorageMasterTests
    {
        private StorageMaster storageMaster;

        [SetUp]
        public void SetUp()
        {
            storageMaster = new StorageMaster();
        }

        
    }
}
