[![Build Status](https://codefirst.iut.uca.fr/api/badges/mamadou_elaphi.arafa/DEpoMvvmMaison/status.svg)](https://codefirst.iut.uca.fr/mamadou_elaphi.arafa/DEpoMvvmMaison)  
[![Quality Gate Status](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=alert_status)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Bugs](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=bugs)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Code Smells](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=code_smells)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Coverage](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=coverage)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)  
[![Duplicated Lines (%)](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=duplicated_lines_density)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Lines of Code](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=ncloc)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Maintainability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=sqale_rating)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Reliability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=reliability_rating)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)  
[![Security Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=security_rating)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Technical Debt](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=sqale_index)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)
[![Vulnerabilities](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=DEpoMvvmMaison&metric=vulnerabilities)](https://codefirst.iut.uca.fr/sonar/dashboard?id=DEpoMvvmMaison)  

 
# DEpoMvvmMaison

Welcome on the DEpoMvvmMaison project! 

Attendu :

    la réalisation d'un toolkit MVVM (bibliothèque de classes),
    le wrapping des classes du modèle par des VM (à chaque fois que c'est nécessaire),
    l'utilisation de commandes pour les différentes fonctionnalités,
    l'utilisation d'une VM applicative (navigation, index, sélection...).


### ce qui a éte fais :

  ✓  l'affichage de la collection de Champions. La possibilité de naviguer de n en n champions (5 champions par page, ou 10, etc.) et la pagination doivent être gérées.

   ✓ Permettez la sélection d'un champion pour le voir dans une page (on n'utilisera que ses propriétés simples (Name, Bio, Icon) puis LargeImage).

   ✓ Ajoutez la gestion des caractéristiques (Characteristics).   

   ✓ Ajoutez la gestion de la classe du champion.


   ✓ Permettez la modification d'un champion existant (depuis la page du champion, et depuis un swipe sur l'item sélectionné dans la collection).

   ✓ Permettez l'ajout d'un nouveau champion.

   ✓ Ajoutez la gestion des skills.

   ✗ Ajoutez la gestion des skins. 
   

 ### Detail de ce qui n'a pas éte fait 
 ✗  J'ai pas pu fair la modification de caracteristique et
  l'ajout de la gestion de skins 
 ### simplifications apportées par le toolkit
 Le Toolkit m'a simplifié et illustré les tâches cela m'a permit de supprimer beaucoup de code passe-partout, en utilisant à la place des annotations et des classes partielles, et tout en conservant assez de contrôle sur la façon dont les propriétés ont été définies, etc. 
## Fais par:
* [Mamadou Elaphi ARAFA](https://codefirst.iut.uca.fr/git/mamadou_elaphi.arafa)
### Explication du code MvvmMaison 
Mon code comporte plusieurs parties :
Modele ,Mvue (vues),VM Applicative et Vm
### Explication du code MvvmMaison 
Le MVVM est une façon de construire une application en trois parties : 
le modèle, la vue et le ViewModel. Le modèle représente les données, 
la vue est ce que l'utilisateur voit à l'écran, et le ViewModel fait le lien entre les deux. 
Le ViewModel prend les données du modèle et les rend disponibles pour la vue. Il permet également à la vue de mettre à jour les données du modèle. Cela rend le code plus facile à réutiliser, à comprendre et à améliorer. 
### Emplacement

    Master => Contient la MVVM de la maison
    Branche toolkit => Contient MVVM Toolkit


_Generated with a_ **Code#0** _template_  
<img src="Documentation/doc_images/CodeFirst.png" height=40/>   