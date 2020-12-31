using System;
using VerificardorCedular;

Console.WriteLine(
    VerifyIdentityCard.IdentificationCard(
        new int[] { 0, 0, 1, 0, 0, 3, 4, 2, 1, 7, 9 }));

Console.ReadKey();

