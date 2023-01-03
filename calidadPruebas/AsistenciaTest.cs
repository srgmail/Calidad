using calidad.BLL;
using calidad.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace calidadPruebas
{
    /// <summary>
    /// Summary description for Asistencia
    /// </summary>
    [TestClass]
    public class AsistenciaTest
    {
        public AsistenciaTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void registrarAsistenciaTest()
        {
            Asistencia oAsistencia = new Asistencia();
            oAsistencia.IdMiembro = 116740086;
            oAsistencia.IdEvento = 12;
            oAsistencia.Fecha = DateTime.Now;
            oAsistencia.IdUsuario = "neiichango@gmail.com";
            oAsistencia.asistencia = true;

            BLLAsistencia target = new BLLAsistencia();

            Asistencia result = null;
                result = target.SaveAsistencia(oAsistencia);


            Assert.IsNotNull(result,
                "x:<{0}>",
                new object[] { result });

        }
    }
}
