using System.Collections.Generic;

namespace Modèle
{
    /// <summary>
    /// Mise en place de la persistance via interface
    /// </summary>
    public interface IPersistanceManager
    {
        (IEnumerable<Item> items, IEnumerable<Set> sets, IEnumerable<Compte> comptes, bool RememberMe, string RememberLogin) ChargeDonnées();

        void SauvegarderDonnées(IEnumerable<Item> items, IEnumerable<Set> sets, IEnumerable<Compte> comptes, bool RememberMe, string RememberLogin);
    }
}
