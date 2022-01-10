using Modèle;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StubLib
{
    /// <summary>
    /// Je s'appelle Stub 
    /// </summary>
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// Méthode qui est censé sauvegarder mais ne fait rien car on est dans un stub
        /// </summary>
        /// <param name="items"></param>
        /// <param name="sets"></param>
        /// <param name="comptes"></param>
        public void SauvegarderDonnées(IEnumerable<Item> items, IEnumerable<Set> sets, IEnumerable<Compte> comptes, bool RememberMe, string RememberLogin)
        {
            Debug.WriteLine("I'll save ! (probably)");
            Debug.WriteLine("No, it's a joke ! (maybe)");
        }

        /// <summary>
        /// Méthode qui permet de charger les données des différentes listes de (Item, Set & Compte)
        /// </summary>
        /// <returns></returns>
        public (IEnumerable<Item> items, IEnumerable<Set> sets, IEnumerable<Compte> comptes, bool RememberMe, string RememberLogin) ChargeDonnées()
        {
            List<Item> items = new List<Item>();

            ////// Liste des items :


            /// Anthennas
            Item cuckoo_clock = new Item("Cuckoo Clock", Rarity.Uncommon.ToString(), Specification.Antennas.ToString(), Certification.none.ToString(), "Tradeup", new DateTime(2017, 10, 28), Color.Grey.ToString(), true, false, false, 15, "../ImagesSources/sources/antennas/cuckoo_clock.png");
            Item giant_panda = new Item("Giant Panda", Rarity.Uncommon.ToString(), Specification.Antennas.ToString(), Certification.Turtle.ToString(), "Tradeup", new DateTime(2017, 10, 28), Color.none.ToString(), false, true, false, 15, "../ImagesSources/sources/antennas/giant_panda.png");
            Item gold_nugget = new Item("Gold Nugget", Rarity.Limited.ToString(), Specification.Antennas.ToString(), Certification.none.ToString(), "Beta", new DateTime(2015, 5, 24), Color.none.ToString(), false, false, false, 17500, "../ImagesSources/sources/antennas/gold_nugget.png");
            Item mage_glass_ii = new Item("Mage Glass II", Rarity.Limited.ToString(), Specification.Antennas.ToString(), Certification.none.ToString(), "Rocketpass 1", new DateTime(2018, 9, 5), Color.none.ToString(), false, false, false, 60, "../ImagesSources/sources/antennas/mage_glass_ii.png");
            Item rubber_duckie = new Item("Rubber Duckie", Rarity.Uncommon.ToString(), Specification.Antennas.ToString(), Certification.Sweeper.ToString(), "Paint & Tradeup", new DateTime(2016, 6, 20), Color.none.ToString(), false, true, false, 15, "../ImagesSources/sources/antennas/rubber_duckie.png");

            items.Add(cuckoo_clock);
            items.Add(giant_panda);
            items.Add(gold_nugget);
            items.Add(mage_glass_ii);
            items.Add(rubber_duckie);


            //// Banners
            Item bobs_ramen = new Item("Bob's Ramen", Rarity.Very_Rare.ToString(), Specification.Banners.ToString(), Certification.none.ToString(), "Elevation, Golden Egg/Pumpkin/Gift", new DateTime(2018, 10, 8), Color.Titanium_White.ToString(), true, false, true, 350, "../ImagesSources/sources/banners/bobs_ramen.png");
            Item faboo = new Item("Faboo", Rarity.Limited.ToString(), Specification.Banners.ToString(), Certification.none.ToString(), "Season 2", new DateTime(2020, 12, 9), Color.none.ToString(), false, false, false, 15, "../ImagesSources/sources/banners/faboo.png");
            Item neoctane = new Item("NeOctane", Rarity.Rare.ToString(), Specification.Banners.ToString(), Certification.none.ToString(), "Radical Summer, '80s Culture", new DateTime(2019, 7, 1), Color.Pink.ToString(), true, false, true, 125, "../ImagesSources/sources/banners/neoctane.png");
            Item rl_esports = new Item("RL Esports", Rarity.Limited.ToString(), Specification.Banners.ToString(), Certification.none.ToString(), "RLCS FAN Rewards", new DateTime(2018, 3, 10), Color.none.ToString(), false, false, false, 40, "../ImagesSources/sources/banners/rl_esports.png");
            Item tranquil_toff = new Item("Tranquil Toff", Rarity.Rare.ToString(), Specification.Banners.ToString(), Certification.none.ToString(), "Momentum", new DateTime(2020, 6, 23), Color.none.ToString(), false, false, true, 90, "../ImagesSources/sources/banners/tranquil_toff.png");

            items.Add(bobs_ramen);
            items.Add(faboo);
            items.Add(neoctane);
            items.Add(rl_esports);
            items.Add(tranquil_toff);


            //// Boddies
            Item komodo = new Item("Komodo", Rarity.Exotic.ToString(), Specification.Bodies.ToString(), Certification.GoalKeeper.ToString(), "Ignition Series", new DateTime(2020, 3, 11), Color.Forest_Green.ToString(), true, true, true, 550, "../ImagesSources/sources/bodies/komodo.png");
            Item octane = new Item("Octane", Rarity.Import.ToString(), Specification.Bodies.ToString(), Certification.Scorer.ToString(), "Tradeup", new DateTime(2017, 8, 3), Color.Titanium_White.ToString(), true, true, false, 14250, "../ImagesSources/sources/bodies/octane.png");
            Item octane_zrs = new Item("Octane ZSR", Rarity.Import.ToString(), Specification.Bodies.ToString(), Certification.Sniper.ToString(), "CC4", new DateTime(2016, 12, 7), Color.none.ToString(), false, true, true, 70, "../ImagesSources/sources/bodies/octane_zsr.png");
            Item samurai = new Item("Samurai", Rarity.Import.ToString(), Specification.Bodies.ToString(), Certification.GoalKeeper.ToString(), "Triumph", new DateTime(2018, 4, 3), Color.Crimson.ToString(), true, true, true, 125, "../ImagesSources/sources/bodies/samurai.png");
            Item takumi = new Item("Takumi", Rarity.Very_Rare.ToString(), Specification.Bodies.ToString(), Certification.none.ToString(), "", new DateTime(2020, 9, 23), Color.none.ToString(), false, false, false, 40, "../ImagesSources/sources/bodies/takumi.png");

            items.Add(komodo);
            items.Add(octane);
            items.Add(octane_zrs);
            items.Add(samurai);
            items.Add(takumi);


            //// Boosts
            Item battle_stars = new Item("Battle-Stars", Rarity.Rare.ToString(), Specification.Boosts.ToString(), Certification.none.ToString(), "FTP", new DateTime(2020, 10, 23), Color.none.ToString(), false, false, false, 15, "../ImagesSources/sources/boosts/battle_stars.png");
            Item hearts = new Item("Hearts", Rarity.Very_Rare.ToString(), Specification.Boosts.ToString(), Certification.none.ToString(), "Paint & Tradeup", new DateTime(2016, 6, 20), Color.none.ToString(), false, false, false, 40, "../ImagesSources/sources/boosts/hearts_boost.png");
            Item lightning = new Item("Lightning", Rarity.Import.ToString(), Specification.Boosts.ToString(), Certification.GoalKeeper.ToString(), "Tradeup", new DateTime(2017, 8, 3), Color.Pink.ToString(), true, true, false, 200, "../ImagesSources/sources/boosts/lightning.png");
            Item quasar = new Item("Quasar", Rarity.Very_Rare.ToString(), Specification.Boosts.ToString(), Certification.Guardian.ToString(), "Momentum", new DateTime(2020, 6, 23), Color.Burnt_Sienna.ToString(), true, true, true, 250, "../ImagesSources/sources/boosts/quasar.png");
            Item virtual_wave = new Item("Virtual Wave", Rarity.Import.ToString(), Specification.Boosts.ToString(), Certification.Scorer.ToString(), "Zephyr", new DateTime(2018, 7, 30), Color.Black.ToString(), true, true, true, 200, "../ImagesSources/sources/boosts/virtual_wave.png");

            items.Add(battle_stars);
            items.Add(hearts);
            items.Add(lightning);
            items.Add(quasar);
            items.Add(virtual_wave);


            //// Decals
            Item dominus_nightmare_fuel = new Item("Dominus Nightmare", Rarity.Limited.ToString(), Specification.Decals.ToString(), Certification.Sniper.ToString(), "RocketPass 4", new DateTime(2019, 9, 28), Color.Cobalt.ToString(), true, true, false, 75, "../ImagesSources/sources/decals/dominus_nightmare_fuel.png");
            Item endo_mg = new Item("Endo MG-88", Rarity.Import.ToString(), Specification.Decals.ToString(), Certification.Acrobat.ToString(), "Nitro, Golden Pumpking/Gift/Egg", new DateTime(2017, 5, 10), Color.none.ToString(), true, true, true, 60, "../ImagesSources/sources/decals/endo_mg.png");
            Item fire_god = new Item("Fire God", Rarity.Black_Market.ToString(), Specification.Decals.ToString(), Certification.Paragon.ToString(), "Too many (almost every crates)", new DateTime(2018, 5, 29), Color.none.ToString(), false, true, true, 750, "../ImagesSources/sources/decals/fire_god.png");
            Item octane_distortion = new Item("Octane Distortion", Rarity.Import.ToString(), Specification.Decals.ToString(), Certification.Victor.ToString(), "Champion, Golden Egg", new DateTime(2016, 9, 8), Color.none.ToString(), false, true, true, 60, "../ImagesSources/sources/decals/octane_distortion.png");
            Item wet_paint = new Item("Wet Paint", Rarity.Black_Market.ToString(), Specification.Decals.ToString(), Certification.Juggler.ToString(), "Elevation", new DateTime(2018, 10, 8), Color.Orange.ToString(), true, true, true, 400, "../ImagesSources/sources/decals/wet_paint.png");

            items.Add(dominus_nightmare_fuel);
            items.Add(endo_mg);
            items.Add(fire_god);
            items.Add(octane_distortion);
            items.Add(wet_paint);


            //// Explosions ////
            Item buffy_sugo = new Item("Buffy-Sugo", Rarity.Black_Market.ToString(), Specification.Explosions.ToString(), Certification.Victor.ToString(), "Season 1", new DateTime(2020, 10, 19), Color.Lime.ToString(), true, true, true, 950, "../ImagesSources/sources/explosions/buffy_sugo.png");
            Item butterflies = new Item("Butterflies", Rarity.Exotic.ToString(), Specification.Explosions.ToString(), Certification.GoalKeeper.ToString(), "Spring Fever", new DateTime(2018, 3, 19), Color.none.ToString(), false, true, true, 1800, "../ImagesSources/sources/explosions/butterflies.png");
            Item reaper = new Item("Reaper", Rarity.Import.ToString(), Specification.Explosions.ToString(), Certification.Tactician.ToString(), "Haunted Hallows", new DateTime(2017, 10, 16), Color.Sky_Blue.ToString(), true, true, true, 35000, "../ImagesSources/sources/explosions/reaper.png");
            Item singularity = new Item("Singularity", Rarity.Black_Market.ToString(), Specification.Explosions.ToString(), Certification.Paragon.ToString(), "Zephyr, Elevation, Golden Egg/Gift/Punpkin", new DateTime(2018, 7, 30), Color.Purple.ToString(), true, true, true, 200, "../ImagesSources/sources/explosions/singularity.png");
            Item supernova_iii = new Item("Supernova III", Rarity.Limited.ToString(), Specification.Explosions.ToString(), Certification.Guardian.ToString(), "Rocketpass 1", new DateTime(2018, 8, 5), Color.Titanium_White.ToString(), true, true, false, 450, "../ImagesSources/sources/explosions/supernova_iii.png");

            items.Add(buffy_sugo);
            items.Add(butterflies);
            items.Add(reaper);
            items.Add(singularity);
            items.Add(supernova_iii);


            //// Paints
            Item furry = new Item("Furry", Rarity.Import.ToString(), Specification.Paints.ToString(), Certification.none.ToString(), "TC Release", new DateTime(2017, 3, 22), Color.none.ToString(), false, false, true, 60, "../ImagesSources/sources/paints/furry.png");
            Item metallic_flake = new Item("Metallic Flake", Rarity.Limited.ToString(), Specification.Paints.ToString(), Certification.none.ToString(), "Rocketpass 1", new DateTime(2018, 8, 5), Color.none.ToString(), false, false, false, 250, "../ImagesSources/sources/paints/metallic_flake.png");
            Item moon_rock = new Item("Moon Rock", Rarity.Rare.ToString(), Specification.Paints.ToString(), Certification.none.ToString(), "Tradeup Update 2", new DateTime(2017, 7, 28), Color.none.ToString(), false, false, false, 40, "../ImagesSources/sources/paints/moon_rock.png");
            Item straight_line = new Item("Straight-Line", Rarity.Very_Rare.ToString(), Specification.Paints.ToString(), Certification.none.ToString(), "Ferocity", new DateTime(2019, 2, 25), Color.none.ToString(), false, false, true, 60, "../ImagesSources/sources/paints/straight_line.png");
            Item toon_wood = new Item("Toon Wood", Rarity.Rare.ToString(), Specification.Paints.ToString(), Certification.none.ToString(), "Game Begin", new DateTime(2015, 7, 7), Color.none.ToString(), false, false, false, 15, "../ImagesSources/sources/paints/toon_wood.png");

            items.Add(furry);
            items.Add(metallic_flake);
            items.Add(moon_rock);
            items.Add(straight_line);
            items.Add(toon_wood);


            //// Toppers
            Item fruit_hat = new Item("Fruit Hat", Rarity.Uncommon.ToString(), Specification.Toppers.ToString(), Certification.Sweeper.ToString(), "Paint & Tradeup", new DateTime(2016, 6, 20), Color.Forest_Green.ToString(), true, true, false, 30, "../ImagesSources/sources/toppers/fruit_hat.png");
            Item happy_new_year = new Item("Happy New Year", Rarity.Limited.ToString(), Specification.Toppers.ToString(), Certification.none.ToString(), "Frosty Fest", new DateTime(2019, 12, 16), Color.none.ToString(), false, false, false, 125, "../ImagesSources/sources/toppers/happy_new_year.png");
            Item octopus = new Item("Octopus", Rarity.Rare.ToString(), Specification.Toppers.ToString(), Certification.none.ToString(), "Tradeup Update 2", new DateTime(2017, 9, 28), Color.Black.ToString(), true, false, false, 900, "../ImagesSources/sources/toppers/octopus.png");
            Item robo_visor = new Item("ROBO-Visor", Rarity.Rare.ToString(), Specification.Toppers.ToString(), Certification.none.ToString(), "Paint & Tradeup", new DateTime(2016, 6, 20), Color.none.ToString(), false, false, false, 15, "../ImagesSources/sources/toppers/robo_visor.png");
            Item wildcat_ears = new Item("Wildcat Ears", Rarity.Rare.ToString(), Specification.Toppers.ToString(), Certification.none.ToString(), "Paint & Tradeup", new DateTime(2016, 6, 20), Color.Forest_Green.ToString(), true, false, false, 250, "../ImagesSources/sources/toppers/wildcat_ears.png");

            items.Add(fruit_hat);
            items.Add(happy_new_year);
            items.Add(octopus);
            items.Add(robo_visor);
            items.Add(wildcat_ears);


            //// Trails
            Item friction = new Item("Friction", Rarity.Very_Rare.ToString(), Specification.Trails.ToString(), Certification.Playmaker.ToString(), "Overdrive, Golden Gift/Latern", new DateTime(2017, 7, 5), Color.none.ToString(), false, true, true, 50, "../ImagesSources/sources/trails/friction.png");
            Item laser_wave_iii_saffron = new Item("Laser Wave III", Rarity.Limited.ToString(), Specification.Trails.ToString(), Certification.Turtle.ToString(), "Rocketpass 1", new DateTime(2018, 9, 5), Color.Saffron.ToString(), true, true, false, 125, "../ImagesSources/sources/trails/laser_wave_iii.saffron.png");
            Item laser_wave_iii_white = new Item("Laser Wave III", Rarity.Limited.ToString(), Specification.Trails.ToString(), Certification.Show_Off.ToString(), "Rocketpass 1", new DateTime(2018, 9, 5), Color.Titanium_White.ToString(), true, true, false, 125, "../ImagesSources/sources/trails/laser_wave_iii.white.png");
            Item lightspeed = new Item("Lightspeed", Rarity.Very_Rare.ToString(), Specification.Trails.ToString(), Certification.Striker.ToString(), "ODC", new DateTime(2017, 7, 5), Color.Purple.ToString(), true, true, true, 125, "../ImagesSources/sources/trails/lightspeed.png");
            Item luminous = new Item("Luminous", Rarity.Very_Rare.ToString(), Specification.Trails.ToString(), Certification.Aviator.ToString(), "Visitor", new DateTime(2018, 2, 7), Color.none.ToString(), false, true, true, 60, "../ImagesSources/sources/trails/luminous.png");

            items.Add(friction);
            items.Add(laser_wave_iii_saffron);
            items.Add(laser_wave_iii_white);
            items.Add(lightspeed);
            items.Add(luminous);


            //// Wheels
            Item ripper = new Item("Ripper", Rarity.Rare.ToString(), Specification.Wheels.ToString(), Certification.Tactician.ToString(), "FTP", new DateTime(2020, 9, 23), Color.none.ToString(), false, true, false, 15, "../ImagesSources/sources/wheels/ripper.png");
            Item stern_uncommon = new Item("Stern", Rarity.Uncommon.ToString(), Specification.Wheels.ToString(), Certification.Scorer.ToString(), "Paint & Tradeup", new DateTime(2016, 6, 20), Color.Lime.ToString(), true, true, false, 75, "../ImagesSources/sources/wheels/stern.uncommon.png");
            Item stern_very_rare = new Item("Stern", Rarity.Very_Rare.ToString(), Specification.Wheels.ToString(), Certification.Guardian.ToString(), "Unknow", new DateTime(666, 6, 6), Color.Grey.ToString(), true, true, false, 125, "../ImagesSources/sources/wheels/stern.very_rare.png");
            Item x_tempo_radiant = new Item("X-Tempo: Radiant", Rarity.Import.ToString(), Specification.Wheels.ToString(), Certification.Juggler.ToString(), "Season 2", new DateTime(2021, 2, 23), Color.Burnt_Sienna.ToString(), true, true, true, 450, "../ImagesSources/sources/wheels/x_tempo_radiant.png");
            Item zomba = new Item("Zomba", Rarity.Exotic.ToString(), Specification.Wheels.ToString(), Certification.Sweeper.ToString(), "Champion, Players Choice, Revival, Golden Egg/Pumpkin", new DateTime(2016, 12, 7), Color.Titanium_White.ToString(), true, true, true, 1900, "../ImagesSources/sources/wheels/zomba.png");

            items.Add(ripper);
            items.Add(stern_uncommon);
            items.Add(stern_very_rare);
            items.Add(x_tempo_radiant);
            items.Add(zomba);

            //// C'est enfin fini !! (absolument tous ces items sont réels :sob:)



            ////// Liste des sets :


            List<Set> sets = new List<Set>();

            Set set0 = new Set("Guest Set");
            Set set1 = new Set("Le Premier Set");
            Set set2 = new Set("Le blanc c'est beau !");
            Set set3 = new Set("Et pourquoi pas ?");



            set1.SetAdd(x_tempo_radiant, false);
            set1.SetAdd(friction, false);


            set2.SetAdd(bobs_ramen, false);
            set2.SetAdd(octane, false);
            set2.SetAdd(laser_wave_iii_white, false);
            set2.SetAdd(zomba, false);


            set3.SetAdd(ripper, false);
            set3.SetAdd(laser_wave_iii_saffron, false);


            sets.Add(set1);
            sets.Add(set2);
            sets.Add(set3);


            ////// Liste des comptes :


            List<Compte> comptes = new List<Compte>();

            // On devait pas faire comme ça (pour le compte guest) à la base mais bon . . . 
            Compte guest = new Compte("Guest", "", "", "../ImagesSources/testPP/icone_profile.png");

            Compte compte1 = new Compte("Login", "azerty", "Login@gmail.com", "../ImagesSources/testPP/weeb.jpg");
            Compte compte2 = new Compte("HandyS11", "azerty", "handys11@gmail.com", "../ImagesSources/testPP/cassiopeia.png");
            Compte compte3 = new Compte("Jordan", "12345", "jordan@gmail.com", "../ImagesSources/testPP/wtc.jpg");
            Compte compte4 = new Compte("Chevaldonné", "azerty", "marc.chevaldonne@mail.com", "../ImagesSources/testPP/licorne.png");

            guest.CompteAdd(set0);

            compte1.CompteAdd(set1);
            compte1.CompteAdd(set3);

            compte2.CompteAdd(set1);
            compte2.CompteAdd(set2);
            compte2.CompteAdd(set3);

            compte3.CompteAdd(set2);
            compte3.CompteAdd(set1);

            compte4.CompteAdd(set1);
            compte4.CompteAdd(set2);
            compte4.CompteAdd(set3);


            comptes.Add(guest);
            comptes.Add(compte1);
            comptes.Add(compte2);
            comptes.Add(compte3);
            comptes.Add(compte4);



            bool RememberMe = false;
            string RememberLogin = "";

            return (items, sets, comptes, RememberMe, RememberLogin);
        }
    }
}