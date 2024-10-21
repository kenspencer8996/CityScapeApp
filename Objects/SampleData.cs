using CityScapeApp.Objects.Entities;

namespace CityScapeApp.Objects
{
    public static class SampleData

    {
  
        public static async void CreateSampleUsers()
        {
 
            PersonEntity newpersonEntity = new PersonEntity();
            PersonEntity personEntity = new PersonEntity();
            PersonEntity catoripersonEntity = new PersonEntity();
            PersonEntity badperson1Entity = new PersonEntity();
            PersonEntity badperson2Entity = new PersonEntity();
            PersonEntity badperson3Entity = new PersonEntity();
            PersonEntity badperson4Entity = new PersonEntity();

            PersonImageEntity image1 = new PersonImageEntity();
            image1.Name = "girl_1";
            image1.FilePath = "girl_1.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = newpersonEntity.PersonId;
            image1.PersonImageStatus = PersonImageStatusEnum.LookingRight45;
            Global.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_1_head";
            image1.FilePath = "girl_1_head.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.LookingRight45;
            Global.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_2_slacks_45deg";
            image1.FilePath = "girl_2_slacks_45deg.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.HeadLookingLeft45;
            Global.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_2_slacks_front";
            image1.FilePath = "girl_2_slacks_front.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.Facing;
            Global.ImageRepository.UpsertPersonImage(image1);
            image1 = new PersonImageEntity();
            image1.Name = "girl_2_slacks_side";
            image1.FilePath = "girl_2_slacks_side.jpg";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            image1.FKPersonId = 0;
            image1.PersonImageStatus = PersonImageStatusEnum.LookingLeft;
            Global.ImageRepository.UpsertPersonImage(image1);

            catoripersonEntity = await Global.InsertPersonAsync("Catori", true, PersonEnum.Individual,"girl_8.png");
            newpersonEntity = await Global.InsertPersonAsync("Joe", false, PersonEnum.Individual, "man_1.png");
            newpersonEntity = await Global.InsertPersonAsync("Jeff", false, PersonEnum.Individual, "man_1.png");
            newpersonEntity = await Global.InsertPersonAsync("Quyen", false, PersonEnum.Individual, "girl_1.png");
            newpersonEntity = await Global.InsertPersonAsync("Papa", false, PersonEnum.Individual, "man_3.png");
            newpersonEntity = await Global.InsertPersonAsync("Gaga", false, PersonEnum.Individual, "girl_2_slacks_45deg.png");
            newpersonEntity = await Global.InsertPersonAsync("Sam", false, PersonEnum.Individual, "man_3.png");
            newpersonEntity = await Global.InsertPersonAsync("Byron", false, PersonEnum.Individual, "man_5.png");
            newpersonEntity = await Global.InsertPersonAsync("Dwayne", false, PersonEnum.Individual, "man_6.png");
            newpersonEntity = await Global.InsertPersonAsync("Merle", false, PersonEnum.Individual, "man_7.png");

            badperson1Entity = await Global.InsertPersonAsync("JohnD", false, PersonEnum.BadGuy, "badguy_2_smirk.png");
            badperson2Entity = await Global.InsertPersonAsync("BuggsyS", false, PersonEnum.BadGuy, "badguy_6_mad.png");
            badperson3Entity = await Global.InsertPersonAsync("ClydeB", false, PersonEnum.BadGuy, "badguy_3.png");
            badperson4Entity = await Global.InsertPersonAsync("DocH", false, PersonEnum.BadGuy, "badguy_4.png");


            Global.InsertPersonImage("badguy_6_armsdown", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.Normal,
                   "badguy_6_armsdown.png", "Normal", badperson1Entity.PersonId);
            Global.InsertPersonImage("badguy_6_cashgun", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.CashGun,
        "badguy_6_cashgun.png", "CashGun", badperson1Entity.PersonId);
            Global.InsertPersonImage("badguy_6_mad", PersonImageTypeEnum.BadGuy,
                PersonImageStatusEnum.Mad,
                    "badguy_6_mad.png", "Mad", badperson1Entity.PersonId);
            Global.InsertPersonImage("badguy_6_wcash", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.Cash,
                    "badguy_6_wcash.png", "Cash", badperson1Entity.PersonId);
            Global.InsertPersonImage("badguy_6_withgun", PersonImageTypeEnum.BadGuy,
                PersonImageStatusEnum.Gun,
          "badguy_6_withgun.png", "Gun", badperson1Entity.PersonId);
            Global.InsertPersonImage("badguy_6_wloot", PersonImageTypeEnum.BadGuy, 
                PersonImageStatusEnum.Loot,
                      "badguy_6_wloot.png", "loot", badperson1Entity.PersonId);

            Global.InsertPersonImage("badguy_2_armsdown", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.ArmsDown,
                           "badguy_2_armsdown.png", "ArmsDown", badperson2Entity.PersonId);
            Global.InsertPersonImage("badguy_2_cashpiles", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.CashPiles,
                           "badguy_2_cashpiles.png", "CashPiles", badperson2Entity.PersonId);
            Global.InsertPersonImage("badguy_2_computer", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Computer,
                           "badguy_2_computer.png", "computer", badperson2Entity.PersonId);

            Global.InsertPersonImage("badguy_2_money", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                           "badguy_2_money.png", "Money", badperson2Entity.PersonId);

            Global.InsertPersonImage("badguy_2_smirk", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                          "badguy_2_smirk.png", "Smirk", badperson2Entity.PersonId);
            
            Global.InsertPersonImage("badguy_3", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
                          "badguy_3.png", "Drinking", badperson3Entity.PersonId);
            
            Global.InsertPersonImage("badguy_4", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                          "badguy_4.png", "Money", badperson4Entity.PersonId);
            Global.InsertPersonImage("badguy_4_armsup", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.ArmsUp,
                          "badguy_4armsup.png", "Arms Up", badperson4Entity.PersonId);
            Global.InsertPersonImage("badguy_4_mojojojo", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Drinking,
                          "badguy_4_mojojojo.png", "Drinking", badperson4Entity.PersonId);
            Global.InsertPersonImage("badguy_4_armsdown", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.ArmsDown,
                   "badguy_4_armsdown.png", "Arms Down", badperson4Entity.PersonId);
            Global.InsertPersonImage("badguy_4", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Devil,
                           "badguy_4.png", "Devil", badperson4Entity.PersonId);

            //Global.InsertImagetype("badguy_5amsout", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //   "badguy_5amsout.png", "Drinking", badperson1Entity.PersonId);
            //Global.InsertImagetype("badguy_4mojojojo", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //               "badguy_4mojojojo.png", "Drinking", 0);
           
            //Global.InsertImagetype("badguy_lootgun", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //               "badguy_lootgun.png", "Loot Gun", 0);
            //Global.InsertImagetype("badguy_mad", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Normal,
            //               "badguy_mad.png", "Mad", 0);

            //Global.InsertImagetype("badguy_wcash", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Cash,
            //               "badguy_wcash.jpg", "Cash", 0);
            //Global.InsertImagetype("badguy_withgun", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Gun,
            //                "badguy_withgun.jpg", "Gun", 0);
            //Global.InsertImagetype("badguy_wloot", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Loot,
            //                "badguy_wloot.jpg", "Loot", 0);

            Global.InsertPersonImage("girl_8", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Facing,
                            "girl_8.png", "", catoripersonEntity.PersonId);
            Global.InsertPersonImage("girl_8_airguitar", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Airguitar,
                            "girl_8_airguitar.png", "", catoripersonEntity.PersonId);
            Global.InsertPersonImage("girl_8_dancing", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Dancig,
                            "girl_8_dancing.png", "", catoripersonEntity.PersonId);
            Global.InsertPersonImage("girl_8_lookingback", PersonImageTypeEnum.Normal, PersonImageStatusEnum.LookimgBack,
                            "girl_8_lookingback.png", "", catoripersonEntity.PersonId);
            Global.InsertPersonImage("girl_8_walking", PersonImageTypeEnum.Normal, PersonImageStatusEnum.Walking,
                            "girl_8_walking.png", "", catoripersonEntity.PersonId);
  
            Global.InsertPersonImage("girl_3_fingerup", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Facing,
                                  "girl_3_fingerup.png", "", 0);
            Global.InsertPersonImage("man_1", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Facing,
                                  "man_1.jpg", "", 0);
            Global.InsertPersonImage("man_3", PersonImageTypeEnum.BadGuy, PersonImageStatusEnum.Facing,
                                  "man_3.png", "", 0);

            Global.InsertBusiness("Jones Fin.", 200, "bank_1.jpg", BusinessTypeEnum.Financial);
            Global.InsertBusiness("123 Bank", 200, "bank_2.jpg", BusinessTypeEnum.Financial);
            Global.InsertBusiness("Iron Factory", 130, "factory_1.jpg", BusinessTypeEnum.Factory);
            Global.InsertBusiness("Auto Factory", 150, "factory_2.jpg", BusinessTypeEnum.Factory);

            Global.InsertHouse("Catories", "house_3d4.jpg", "living_10_roomarmchair.png", "kitchen_1_room.jpg", "garage_1.jpg", true, "Catories");

            Global.InsertHouse("Jeffs", "house_5_dkbrownroofgarage.jpg", "living__7_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "Jeffs");
            Global.InsertHouse("Quyens", "house_3d4.jpg", "living_6_room.jpg", "kitchen_3_room.jpg", "garage_3.jpg", false, "Quyens");
            Global.InsertHouse("Joe", "house_3d4.jpg", "living__7_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "Joe");
            Global.InsertHouse("Papa", "house_6_grayroofgarage.jpg", "living_11_roombig.png", "kitchen_3_room.jpg", "garage_1.jpg", false, "Papa");
            Global.InsertHouse("Gaga", "house_6_grayroofgarage.jpg", "living__7_room.jpg", "kitchen_2_room.jpg", "garage_3.jpg", false, "Gaga");
            Global.InsertHouse("Sara", "houase_13_3dwyard.jpg", "living_11_roombig.png", "kitchen1.jpg", "garage_2.jpg", false, "Sara");
            Global.InsertHouse("John", "house_3d4.jpg", "living__7_room.jpg", "kitchen_3_room.jpg", "garage_1.jpg", false, "John");
            Global.InsertHouse("Gary", "house_5_dkbrownroofgarage.jpg", "living_6_room.jpg", "kitchen_2_room.jpg", "garage_1.jpg", false, "Gary");
            Global.InsertHouse("Sue", "house_6_grayroofgarage.jpg", "living_11_roombig.png", "kitchen1.jpg", "garage_2.jpg", false, "Sue");
            Global.InsertHouse("Bill", "houase_13_3dwyard.jpg", "living__7_room.jpg", "kitchen_3_room.jpg", "garage_3.jpg", false, "Bill");
            Global.InsertHouse("Jack", "house_12_3ds2.jpg", "living_6_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "Jack");
            Global.InsertHouse("June", "house_3d4.jpg", "living_6_room.jpg", "kitchen_2_room.jpg", "garage_2.jpg", false, "June");

            //newpersonEntity = await Global.InsertPersonAsync("Joe Skinny", false, PersonEnum.BadGuy);

            //newpersonEntity = await Global.InsertPersonAsync("Mojo", false, PersonEnum.BadGuy);
            //newpersonEntity = await Global.InsertPersonAsync("sue Devil", false, PersonEnum.BadGuy);
  

        }
    }
}
