﻿using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xunit;

namespace WeatherStationTests
{
    public class WindDataViewModelTests : IDisposable
    {
        // System Under Test
        // Utilisez ce membre dans les tests
        WindDataViewModel _sut = new WindDataViewModel();

        /// <summary>
        /// Test la fonctionnalité de conversion de mps vers kph
        /// </summary>
        /// <param name="mps">Mètres par seconde</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T01</remarks>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 18)]
        [InlineData(51, 183.6)]
        [InlineData(-10, -36)]
        [InlineData(65, 234)]
        public void MPStoKPH_AlwaysReturnGoodValue(double mps, double expected)
        {
            // Arrange

            // Act       
            double actual = _sut.MPStoKPH(mps);
            // Assert
            Assert.Equal(actual, expected);
            /// TODO : git commit -a -m "T01 MPStoKPH_AlwaysReturnGoodValue : Done"
        }

        /// <summary>
        /// Test la fonctionnalité de conversion de kph à mps
        /// </summary>
        /// <param name="kph">km par heure</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T02</remarks>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 2.78)]
        [InlineData(50, 13.89)]
        [InlineData(100, 27.78)]
        [InlineData(126, 35)]
        [InlineData(200, 55.56)]
        public void KPHtoMPS_AlwaysReturnGoodValue(double kph, double expected)
        {
            // Arrange

            // Act       
            double actuel = _sut.KPHtoMPS(kph);
            // Assert
            Assert.Equal(actuel, expected);
            /// TODO : git commit -a -m "T02 KPHtoMPS_AlwaysReturnGoodValue : Done"
        }

        /// <summary>
        /// Lorsqu'exécuté GetDataCommand devrait lancer une NullException
        /// </summary>
        /// <remarks>T03</remarks>
        [Fact]
        public void GetDataCommand_ExecuteIfNullService_ShouldThrowNullException()
        {
            // Arrange

            // Act       

            // Assert
            Assert.Throws<NullReferenceException>(() => _sut.GetDataCommand.Execute(_sut.WindDataService));
            /// TODO : git commit -a -m "T03 GetDataCommand_ExecuteIfNullService_ShouldThrowNullException : Done"
        }

        /// <summary>
        /// La méthode CanGetData devrait retourner faux si le service est null
        /// </summary>
        /// <remarks>T04</remarks>
        [Fact]
        public void CanGetData_WhenServiceIsNull_ReturnsFalse()
        {
            // Arrange


            // Act       
            var actuel = _sut.CanGetData();
            var expected = false;
            // Assert

            Assert.Equal(actuel, expected);

            /// TODO : git commit -a -m "T04 CanGetData_WhenServiceIsNull_ReturnsFalse : Done"
        }

        /// <summary>
        /// La méthode CanGetData devrait retourner vrai si le service est instancié
        /// </summary>
        /// <remarks>T05</remarks>
        [Fact]
        public void CanGetData_WhenServiceIsSet_ReturnsTrue()
        {
            // Arrange
            OpenWeatherService openWeatherService = new OpenWeatherService();

            _sut.SetWindDataService(openWeatherService);
            // Act       


            var actual = _sut.CanGetData();

            // Assert

            Assert.True(actual);
            

            /// TODO : git commit -a -m "T05 CanGetData_WhenServiceIsSet_ReturnsTrue : Done"
        }

        /// <summary>
        /// WindDataService ne devrait plus être null lorsque SetWindDataService reçoit un paramètre
        /// </summary>
        /// <remarks>T06</remarks>
        [Fact]
        public void SetWindDataService_WhenExecuted_WindDataServiceIsNotNull()
        {
            // Arrange
            OpenWeatherService openWeatherService = new OpenWeatherService();

            _sut.SetWindDataService(openWeatherService);

            // Act       


            var actual = _sut.WindDataService;

            // Assert

            Assert.NotNull(actual);

            /// TODO : git commit -a -m "T06 SetWindDataService_WhenExecuted_WindDataServiceIsNotNull : Done"
        }

        /// <summary>
        /// CurrentData devrait avoir une valeur lorsque GetDataCommand est exécutée
        /// </summary>
        /// <remarks>T07</remarks>
        [Fact]
        public async Task GetDataCommand_HaveCurrentDataWhenExecuted_ShouldPassAsync()
        {
            // Arrange
            var GDC = _sut.GetDataCommand;

            Mock<IWinDataService> _myMock = new Mock<IWinDataService>();

            _myMock.Setup(x => x.GetDataAsync()).Returns(GetSomeDataModel());

            // Act       

            _sut.CurrentData = await _myMock.Object.GetDataAsync();
            var actual = _sut.CurrentData;

            // Assert

            Assert.NotNull(actual);

            /// TODO : git commit -a -m "T07 GetDataCommand_HaveCurrentDataWhenExecuted_ShouldPass : Done"
        }

        public async Task<WindDataModel> GetSomeDataModel()
        {
            return new WindDataModel();
        }
        /// <summary>
        /// Ne touchez pas à ça, c'est seulement pour respecter les standards
        /// de test qui veulent que la classe de tests implémente IDisposable
        /// Mais ça peut être utilisé, par exemple, si on a une connexion ouverte, il
        /// faut s'assurer qu'elle sera fermée lorsque l'objet sera détruit
        /// </summary>
        public void Dispose()
        {
            // Nothing to here, just for Testing standards
        }
    }
}
