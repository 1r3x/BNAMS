using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SR.UnitTest
{
    [TestClass]
    public class PasswordChange
    {
        [TestMethod]
        public void GetCurrentPass_By_SessionEmployeeId()
        {
            //var data = new List<UserLogin>
            //{
            //    new UserLogin { Password = "syn!@#",UserName = "dev",EmpId = 1},
            //    new UserLogin { Password = "syn!@#",UserName = "admin",EmpId = 1},
            //}.AsQueryable();

            //var mockSet = new Mock<DbSet<Blog>>();
            //mockSet.As<IDbAsyncEnumerable<Blog>>()
            //    .Setup(m => m.GetAsyncEnumerator())
            //    .Returns(new TestDbAsyncEnumerator<Blog>(data.GetEnumerator()));

            //mockSet.As<IQueryable<Blog>>()
            //    .Setup(m => m.Provider)
            //    .Returns(new TestDbAsyncQueryProvider<Blog>(data.Provider));

            //mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            //var mockContext = new Mock<BloggingContext>();
            //mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);

            //var service = new BlogService(mockContext.Object);
            //var blogs = await service.GetAllBlogsAsync();

            //Assert.AreEqual(3, blogs.Count);
            //Assert.AreEqual("AAA", blogs[0].Name);
            //Assert.AreEqual("BBB", blogs[1].Name);
            //Assert.AreEqual("ZZZ", blogs[2].Name);

        }
    }
}
