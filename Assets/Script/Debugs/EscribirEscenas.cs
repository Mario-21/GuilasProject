using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
public class EscribirEscenas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string rutaAchivo;
    [SerializeField] string nombreArchivo;
    [SerializeField] int numeroTotalEscenas;
    #region Listas
    public List<CameraShake> cameras;
    public List<Derrumbamiento> derrumbamientos;
    public List<Detectar_y_Echar> detectares;
    public List<SelectorNiveles> selectores;
    public List<ControladorListasNivel> controladorListasNiveles;
    public List<CallScene> callScenes;
    public List<LevelButton> levelButtons;
    public List<GoLevel> goLevels;
    public List<MouseItem> mouseItems;
    public List<BossTrigger> bossTriggers;
    public List<PelucaTrigger> pelucaTriggers;
    public List<Detectar_y_Echar_Cameras> detectarYEcharCameras;
    public List<OutWithWrench> outWithWrenches;
    public List<ButtonMadre> buttonMadres;
    public List<ShootEnemyCIn> shootEnemyCIns;
    public List<ButtonMotoAqua> buttonMotoAquas;
    public List<Camino_CambiarZona> camino_CambiarZonas;
    public List<Cambiar_Area> cambiar_Areas;
    public List<OnCinematic> onCinematics;
    public List<BeginCinematic_1> beginCinematic_1s;
    public List<CajaTransporte_Event> cajaTransporte_Events;
    public List<CientificoCinematic> cientificoCinematics;
    public List<RegretScene> regretScenes;
    public List<StartCaveCin> startCaveCins;
    public List<CaveScene> caveScenes;
    public List<NoviceDeathScene> noviceDeathScenes;
    public List<TriggerRecoveryRoom> triggerRecoveryRooms;
    public List<RecoveryRoomCinematic> recoveryRoomCinematics;
    public List<UseSleep> useSleeps;
    public List<GoBoneCin> goBoneCins;
    public List<BoneCin> boneCins;
    public List<GoCin> goCins;
    public List<ElevatorCoche> elevatorCoches;
    public List<FallCinematic> fallCinematics;
    public List<SoltarDialogo> soltarDialogos;
    public List<DurationScene> durationScenes;
    public List<UseCin> useCins;
    public List<Detectar_Echar_Deep> detectarEcharDeeps;
    public List<CompletarNivel> completarNivels;
    public List<DeathMenuController> deathMenuControllers;
    public List<CambiarAreaTutorial> cambiarAreaTutorials;
    public List<CaminoCambiarZonaTutorial> caminoCambiarZonaTutorials;
    #endregion

    [ContextMenu("Archivo que escribe nombre de todas las escenas + index")]
    void CrearArchivosTextoAuto()
    {

        string fullPath = Path.Combine(rutaAchivo, nombreArchivo);
        if (File.Exists(fullPath))
        {
            Debug.Log("Existo, la pereza ha ganado");
        }
        else
        {
            try
            {
                Debug.Log("Me crearon con exito, soy " + nombreArchivo + " " + SceneManager.GetSceneByBuildIndex(0).name);
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        for (int i = 0; i <= numeroTotalEscenas; i++)
                        {
                            string path = SceneUtility.GetScenePathByBuildIndex(i);
                            string nombreEscena = Path.GetFileNameWithoutExtension(path);

                            writer.WriteLine(i + " " + nombreEscena);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error al intentar crear el archivo" + fullPath + "\n" + e);
            }
        }
    }

    [ContextMenu("Nombre Escena")]
    void DebugNombreEscena()
    {
        string path = SceneUtility.GetScenePathByBuildIndex(6);
        string nombreEscena = Path.GetFileNameWithoutExtension(path);

        Debug.Log("Nombre de la escena " + 6 + ": " + nombreEscena);

    }
    
    
    [ContextMenu("Almacenar")]
    public void AlmacenarEstructurasNiveles()
    {

        // Limpiamos las listas por si se llama más de una vez

        #region Listas Limpiar
        cameras.Clear();
        derrumbamientos.Clear();
        detectares.Clear();
        selectores.Clear();
        controladorListasNiveles.Clear();
        callScenes.Clear();
        levelButtons.Clear();
        goLevels.Clear();
        mouseItems.Clear();
        bossTriggers.Clear();
        pelucaTriggers.Clear();
        detectarYEcharCameras.Clear();
        outWithWrenches.Clear();
        buttonMadres.Clear();
        shootEnemyCIns.Clear();
        buttonMotoAquas.Clear();
        camino_CambiarZonas.Clear();
        cambiar_Areas.Clear();
        onCinematics.Clear();
        beginCinematic_1s.Clear();
        cajaTransporte_Events.Clear();
        cientificoCinematics.Clear();
        regretScenes.Clear();
        startCaveCins.Clear();
        caveScenes.Clear();
        noviceDeathScenes.Clear();
        triggerRecoveryRooms.Clear();
        recoveryRoomCinematics.Clear();
        useSleeps.Clear();
        goBoneCins.Clear();
        boneCins.Clear();
        goCins.Clear();
        elevatorCoches.Clear();
        fallCinematics.Clear();
        soltarDialogos.Clear();
        durationScenes.Clear();
        useCins.Clear();
        detectarEcharDeeps.Clear();
        completarNivels.Clear();
        deathMenuControllers.Clear();
        cambiarAreaTutorials.Clear();
        caminoCambiarZonaTutorials.Clear();
        #endregion
        
        // Buscar Objetos
        #region Meter Objetos Buscados Array
        UnityEngine.Object[] rumblingss = BuscarScripts(typeof(Derrumbamiento));
        UnityEngine.Object[] cameras2 = BuscarScripts(typeof(CameraShake));
        UnityEngine.Object[] detectores = BuscarScripts(typeof(Detectar_y_Echar));
        UnityEngine.Object[] selectoresNiveles = BuscarScripts(typeof(SelectorNiveles));
        UnityEngine.Object[] controladores = BuscarScripts(typeof(ControladorListasNivel));
        UnityEngine.Object[] llamadasEscenas = BuscarScripts(typeof(CallScene));
        UnityEngine.Object[] levelesButton = BuscarScripts(typeof(LevelButton));
        UnityEngine.Object[] goLeveles = BuscarScripts(typeof(GoLevel));
        UnityEngine.Object[] mousesitem = BuscarScripts(typeof(MouseItem));
        UnityEngine.Object[] bossesTrigger = BuscarScripts(typeof(BossTrigger));
        UnityEngine.Object[] pelucaTriggeres = BuscarScripts(typeof(PelucaTrigger));
        UnityEngine.Object[] detectoresCamera = BuscarScripts(typeof(Detectar_y_Echar_Cameras));
        UnityEngine.Object[] outWrenches = BuscarScripts(typeof(OutWithWrench));
        UnityEngine.Object[] buttonMadreses = BuscarScripts(typeof(ButtonMadre));
        UnityEngine.Object[] shootEnemies = BuscarScripts(typeof(ShootEnemyCIn));
        UnityEngine.Object[] buttonesMotoAquas = BuscarScripts(typeof(ButtonMotoAqua));
        UnityEngine.Object[] caminos = BuscarScripts(typeof(Camino_CambiarZona));
        UnityEngine.Object[] areas = BuscarScripts(typeof(Cambiar_Area));
        UnityEngine.Object[] oncinematicas = BuscarScripts(typeof(OnCinematic));
        UnityEngine.Object[] beginesCinematiques = BuscarScripts(typeof(BeginCinematic_1));
        UnityEngine.Object[] cajasTransportes = BuscarScripts(typeof(CajaTransporte_Event));
        UnityEngine.Object[] cientificosCinematicas = BuscarScripts(typeof(CientificoCinematic));
        UnityEngine.Object[] regretEscenes = BuscarScripts(typeof(RegretScene));
        UnityEngine.Object[] startCavesCinemas = BuscarScripts(typeof(StartCaveCin));
        UnityEngine.Object[] CavesEscenes = BuscarScripts(typeof(CaveScene));
        UnityEngine.Object[] novicesDeathEscenes = BuscarScripts(typeof(NoviceDeathScene));
        UnityEngine.Object[] triggersRecoveryRoomes = BuscarScripts(typeof(TriggerRecoveryRoom));
        UnityEngine.Object[] usesSleepes = BuscarScripts(typeof(UseSleep));
        UnityEngine.Object[] goesBoneCinematics = BuscarScripts(typeof(GoBoneCin));
        UnityEngine.Object[] BonesCines = BuscarScripts(typeof(BoneCin));
        UnityEngine.Object[] goesCines = BuscarScripts(typeof(GoCin));
        UnityEngine.Object[] elevatoresCoches = BuscarScripts(typeof(ElevatorCoche));
        UnityEngine.Object[] fallesCinematics = BuscarScripts(typeof(FallCinematic));
        UnityEngine.Object[] soltaresdialogues = BuscarScripts(typeof(SoltarDialogo));
        UnityEngine.Object[] durationes = BuscarScripts(typeof(DurationScene));
        UnityEngine.Object[] usesCines = BuscarScripts(typeof(UseCin));
        UnityEngine.Object[] detectaresEcharesDeepes = BuscarScripts(typeof(Detectar_Echar_Deep));
        UnityEngine.Object[] completaresNiveles = BuscarScripts(typeof(CompletarNivel));
        UnityEngine.Object[] deathesMenusControllers = BuscarScripts(typeof(DeathMenuController));
        UnityEngine.Object[] areasTutoriales = BuscarScripts(typeof(CambiarAreaTutorial));
        UnityEngine.Object[] caminosTutoriales = BuscarScripts(typeof(CaminoCambiarZonaTutorial));
        #endregion
        //Añadir a las listas
        #region Añadir a Lista
        EntrarLista<Derrumbamiento>(rumblingss, derrumbamientos);
        EntrarLista<CameraShake>(cameras2, cameras);
        EntrarLista<Detectar_y_Echar>(detectores, detectares);
        EntrarLista<SelectorNiveles>(selectoresNiveles, selectores);
        EntrarLista<ControladorListasNivel>(controladores, controladorListasNiveles);
        EntrarLista<CallScene>(llamadasEscenas, callScenes);
        EntrarLista<LevelButton>(levelesButton, levelButtons);
        EntrarLista<GoLevel>(goLeveles, goLevels);
        EntrarLista<MouseItem>(mousesitem, mouseItems);
        EntrarLista<BossTrigger>(bossesTrigger, bossTriggers);
        EntrarLista<PelucaTrigger>(pelucaTriggeres, pelucaTriggers);
        EntrarLista<Detectar_y_Echar_Cameras>(detectoresCamera, detectarYEcharCameras);
        EntrarLista<OutWithWrench>(outWrenches, outWithWrenches);
        EntrarLista<ButtonMadre>(buttonMadreses, buttonMadres);
        EntrarLista<ShootEnemyCIn>(shootEnemies, shootEnemyCIns);
        EntrarLista<ButtonMotoAqua>(buttonesMotoAquas, buttonMotoAquas);
        EntrarLista<Camino_CambiarZona>(caminos, camino_CambiarZonas);
        EntrarLista<Cambiar_Area>(areas, cambiar_Areas);
        EntrarLista<OnCinematic>(oncinematicas, onCinematics);
        EntrarLista<BeginCinematic_1>(beginesCinematiques, beginCinematic_1s);
        EntrarLista<CajaTransporte_Event>(cajasTransportes, cajaTransporte_Events);
        EntrarLista<CientificoCinematic>(cientificosCinematicas, cientificoCinematics);
        EntrarLista<RegretScene>(regretEscenes, regretScenes);
        EntrarLista<StartCaveCin>(startCavesCinemas, startCaveCins);
        EntrarLista<CaveScene>(CavesEscenes, caveScenes);
        EntrarLista<NoviceDeathScene>(novicesDeathEscenes, noviceDeathScenes);
        EntrarLista<TriggerRecoveryRoom>(triggersRecoveryRoomes, triggerRecoveryRooms);
        EntrarLista<UseSleep>(usesSleepes, useSleeps);
        EntrarLista<GoBoneCin>(goesBoneCinematics, goBoneCins);
        EntrarLista<BoneCin>(BonesCines, boneCins);
        EntrarLista<GoCin>(goesCines, goCins);
        EntrarLista<ElevatorCoche>(elevatoresCoches, elevatorCoches);
        EntrarLista<FallCinematic>(fallesCinematics, fallCinematics);
        EntrarLista<SoltarDialogo>(soltaresdialogues, soltarDialogos);
        EntrarLista<DurationScene>(durationes, durationScenes);
        EntrarLista<UseCin>(usesCines, useCins);
        EntrarLista<Detectar_Echar_Deep>(detectaresEcharesDeepes, detectarEcharDeeps);
        EntrarLista<CompletarNivel>(completaresNiveles, completarNivels);
        EntrarLista<DeathMenuController>(deathesMenusControllers, deathMenuControllers);
        EntrarLista<CambiarAreaTutorial>(areasTutoriales, cambiarAreaTutorials);
        EntrarLista<CaminoCambiarZonaTutorial>(caminosTutoriales, caminoCambiarZonaTutorials);
        #endregion
        //Cambiar int por String
        #region Establecer el String con Int
        //Camera Shake
        if (cameras.Count > 0)
        {
            foreach (CameraShake cameraz in cameras)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(cameraz.zonaModificada);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                cameraz.nombreSiguienteScenaShake = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(cameraz);
#endif
            }

        }
        //Derumbamiento
        if (derrumbamientos.Count > 0)
        {
            foreach(Derrumbamiento derrumbos in derrumbamientos)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(derrumbos.nextLevel);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                derrumbos.nombreSiguienteNivel = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(derrumbos);
#endif
            }
        }
        //Detectar_y_Echar
        if (detectares.Count > 0)
        {
            foreach (Detectar_y_Echar detectar_Y in detectares)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(detectar_Y.sceneReload);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                detectar_Y.escenaNombreRecarga = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(detectar_Y);
#endif
            }
        }
        //SelectorNiveles
        if (selectores.Count > 0)
        {
            foreach (SelectorNiveles selectore in selectores)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(selectore.escenaPantallaCarga);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                selectore.nombreEscenaPantallaCarga = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(selectore);
#endif
            }
        }
        //ControladoresListaNivel
        if (controladorListasNiveles.Count > 0)
        {
            foreach (ControladorListasNivel contro in controladorListasNiveles)
            {
                for(int i = 0; i < contro.informacionNiveles.Count; i++)
                {
                    string path = SceneUtility.GetScenePathByBuildIndex(contro.informacionNiveles[i].scenaNivel);
                    string nombreEscena = Path.GetFileNameWithoutExtension(path);

                    contro.informacionNiveles[i].nombreNivelEscena = nombreEscena;
#if UNITY_EDITOR
                    MarcarDirty(contro);
#endif
                }
            }
        }
        //CallScene
        if (callScenes.Count > 0)
        {
            foreach (CallScene call in callScenes)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(call.scene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                call.nombreEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(call);
#endif
            }
        }
        //LevelButton
        if (levelButtons.Count > 0)
        {
            foreach (LevelButton levelBoton in levelButtons)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(levelBoton.mainCampaign.indexCampaign);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                levelBoton.mainCampaign.nombreEscenaCampaign = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(levelBoton);
#endif
            }
        }
        //GoLevel
        if (goLevels.Count > 0)
        {
            foreach (GoLevel goesleve in goLevels)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(goesleve.goScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                goesleve.nombreEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(goesleve);
#endif
            }
        }
        //MouseItem
        if(mouseItems.Count > 0)
        {
            foreach(MouseItem mouseIteme in mouseItems)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(mouseIteme.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                mouseIteme.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(mouseIteme);
#endif
            }
        }
        //BossTrigger
        if (bossTriggers.Count > 0)
        {
            foreach (BossTrigger bossuTrigger in bossTriggers)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(bossuTrigger.scenaBoss);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                bossuTrigger.nombreEscenaJefe = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(bossuTrigger);
#endif
            }
        }
        //PelucaTrigger
        if (pelucaTriggers.Count > 0)
        {
            foreach (PelucaTrigger chePeluca in pelucaTriggers)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(chePeluca.nextScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                chePeluca.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(chePeluca);
#endif
            }
        }
        //Detectar_y_Echar_Cameras
        if (detectarYEcharCameras.Count > 0)
        {
            foreach (Detectar_y_Echar_Cameras detectar_Y_Echar_Cameras in detectarYEcharCameras)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(detectar_Y_Echar_Cameras.sceneReload);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                detectar_Y_Echar_Cameras.nombreEscenaRecarga = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(detectar_Y_Echar_Cameras);
#endif
            }
        }
        //OutWithWrench
        if (outWithWrenches.Count > 0)
        {
            foreach (OutWithWrench outWrenche in outWithWrenches)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(outWrenche.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                outWrenche.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(outWrenche);
#endif
            }
        }
        //ButtonMadre
        if (buttonMadres.Count > 0)
        {
            foreach (ButtonMadre buttonM in buttonMadres)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(buttonM.escenaGeneradorMadre);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                buttonM.nombreEscenaGeneradorMadre = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(buttonM);
#endif
            }
        }
        //ShootEnemyCIn
        if (shootEnemyCIns.Count > 0)
        {
            foreach (ShootEnemyCIn shootCin in shootEnemyCIns)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(shootCin.nextScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                shootCin.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(shootCin);
#endif
            }
        }
        //ButtonMotoAqua
        if (buttonMotoAquas.Count > 0)
        {
            foreach (ButtonMotoAqua botonMA in buttonMotoAquas)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(botonMA.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                botonMA.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(botonMA);
#endif
            }
        }
        //Camino_CambiarZona
        if (camino_CambiarZonas.Count > 0)
        {
            foreach (Camino_CambiarZona caminanteNoHayCamino in camino_CambiarZonas)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(caminanteNoHayCamino.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                caminanteNoHayCamino.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(caminanteNoHayCamino);
#endif
            }
        }
        //Cambiar_Area
        if (cambiar_Areas.Count > 0)
        {
            foreach (Cambiar_Area cambioArea in cambiar_Areas)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(cambioArea.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                cambioArea.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(cambioArea);
#endif
            }
        }
        //OnCinematic
        if (onCinematics.Count > 0)
        {
            foreach (OnCinematic onCin in onCinematics)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(onCin.sceneCatching);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                onCin.nombreEscenaCin = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(onCin);
#endif
            }
        }
        //BeginCinamatic_1
        if (beginCinematic_1s.Count > 0)
        {
            foreach (BeginCinematic_1 beginC in beginCinematic_1s)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(beginC.volverEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                beginC.nombreVolverEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(beginC);
#endif
            }
        }
        //CajaTransporte_Event
        if (cajaTransporte_Events.Count > 0)
        {
            foreach (CajaTransporte_Event cajaTransporte in cajaTransporte_Events)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(cajaTransporte.escena_Cinematic);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                cajaTransporte.nombreEscenaCinematic = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(cajaTransporte);
#endif
            }
        }
        //CientificoCinematic
        if (cientificoCinematics.Count > 0)
        {
            foreach (CientificoCinematic cC in cientificoCinematics)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(cC.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                cC.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(cC);
#endif
            }
        }
        //RegretScene
        if (regretScenes.Count > 0)
        {
            foreach (RegretScene regretScene in regretScenes)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(regretScene.nextScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                regretScene.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(regretScene);
#endif
            }
        }
        //StartCaveCin
        if (startCaveCins.Count > 0)
        {
            foreach (StartCaveCin startCave in startCaveCins)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(startCave.cinematicCaveLevel);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                startCave.nombreEscenaCinematicCueva = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(startCave);
#endif
            }
        }
        //CaveScene
        if (caveScenes.Count > 0)
        {
            foreach (CaveScene cuevaEscena in caveScenes)
            {
                string pathEscenaMuerte = SceneUtility.GetScenePathByBuildIndex(cuevaEscena.nivelDeath);
                string nombreEscenaMuerte = Path.GetFileNameWithoutExtension(pathEscenaMuerte);

                cuevaEscena.nombreEscenaMuerte = nombreEscenaMuerte;

                string pathEscenaEnfermeria = SceneUtility.GetScenePathByBuildIndex(cuevaEscena.nivelInfarmary);
                string nombreEscenaEnfermeria = Path.GetFileNameWithoutExtension(pathEscenaEnfermeria);

                cuevaEscena.nombreEscenaEnfermeria = nombreEscenaEnfermeria;

#if UNITY_EDITOR
                MarcarDirty(cuevaEscena);
#endif
            }
        }
        //NoviceDeathScene
        if (noviceDeathScenes.Count > 0)
        {
            foreach (NoviceDeathScene noviceDS in noviceDeathScenes)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(noviceDS.nextScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                noviceDS.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(noviceDS);
#endif
            }
        }
        //TriggerRecoveryRoom
        if (triggerRecoveryRooms.Count > 0)
        {
            foreach (TriggerRecoveryRoom recoveryRoom in triggerRecoveryRooms)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(recoveryRoom.cinematicScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                recoveryRoom.nombreSiguienteEscenaCin = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(recoveryRoom);
#endif
            }
        }
        //RecoveryRoomCinematic
        if (recoveryRoomCinematics.Count > 0)
        {
            foreach (RecoveryRoomCinematic recoveryRoomC in recoveryRoomCinematics)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(recoveryRoomC.returnScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                recoveryRoomC.nombreSiguienteEscenaVolver = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(recoveryRoomC);
#endif
            }
        }
        //UseSleep
        if (useSleeps.Count > 0)
        {
            foreach (UseSleep useS in useSleeps)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(useS.cinematicDormitorio);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                useS.nombreSiguienteEscenaCin = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(useS);
#endif
            }
        }
        //GoBoneCin
        if (goBoneCins.Count > 0)
        {
            foreach (GoBoneCin goBoneC in goBoneCins)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(goBoneC.cinematicLevel);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                goBoneC.nombreSiguienteEscenaCin = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(goBoneC);
#endif
            }
        }
        //BoneCin
        if (boneCins.Count > 0)
        {
            foreach (BoneCin boneC in boneCins)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(boneC.levelOriginal);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                boneC.nombreSiguienteEscenaOriginal = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(boneC);
#endif
            }
        }
        //GoCin
        if (goCins.Count > 0)
        {
            foreach (GoCin goC in goCins)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(goC.sceneCin);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                goC.nombreSiguienteEscenaCin = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(goC);
#endif
            }
        }
        //ElevatorCoche
        if (elevatorCoches.Count > 0)
        {
            foreach (ElevatorCoche elevatorC in elevatorCoches)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(elevatorC.cinematic);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                elevatorC.nombreSiguienteEscenaCin = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(elevatorC);
#endif
            }
        }
        //FallCinematic
        if (fallCinematics.Count > 0)
        {
            foreach (FallCinematic fallC in fallCinematics)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(fallC.sceneCin);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                fallC.nombreSiguienteEscenaCin = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(fallC);
#endif
            }
        }
        //SoltarDialogo
        if (soltarDialogos.Count > 0)
        {
            foreach (SoltarDialogo soltarD in soltarDialogos)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(soltarD.returnScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                soltarD.nombreSiguienteEscenaVolver = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(soltarD);
#endif
            }
        }
        //DurationScene 
        if (durationScenes.Count > 0)
        {
            foreach (DurationScene duration in durationScenes)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(duration.scene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                duration.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(duration);
#endif
            }
        }
        //UseCin
        if (useCins.Count > 0)
        {
            foreach (UseCin useC in useCins)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(useC.nextScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                useC.nombreSiguienteEscena = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(useC);
#endif
            }
        }
        //Detectar_Echar_Deep
        if (detectarEcharDeeps.Count > 0)
        {
            foreach (Detectar_Echar_Deep detectarEP in detectarEcharDeeps)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(detectarEP.sceneReload);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                detectarEP.nombreSiguienteEscenaRecargar = nombreEscena;

#if UNITY_EDITOR
                MarcarDirty(detectarEP);
#endif
            }
        }
        //CompletarNivel
        if (completarNivels.Count > 0)
        {
            foreach (CompletarNivel completarN in completarNivels)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(completarN.siguienteNivel);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                completarN.nombreSiguienteEscenaNivel = nombreEscena;
#if UNITY_EDITOR
                MarcarDirty(completarN);
#endif
            }
        }
        //DeathMenuController
        if (deathMenuControllers.Count > 0)
        {
            foreach (DeathMenuController dMC in deathMenuControllers)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(dMC.mainMenuScene);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                dMC.nombreMenuEscena = nombreEscena;

#if UNITY_EDITOR
                MarcarDirty(dMC);
#endif
            }
        }
        //CambiarAreaTutorial
        if (cambiarAreaTutorials.Count > 0)
        {
            foreach (CambiarAreaTutorial cambiarAreaTutorial in cambiarAreaTutorials)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(cambiarAreaTutorial.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                cambiarAreaTutorial.nombreSiguienteEscena = nombreEscena;

#if UNITY_EDITOR
                MarcarDirty(cambiarAreaTutorial);
#endif
            }
        }
        //CaminoCambiarZonaTutorial
        if (caminoCambiarZonaTutorials.Count > 0)
        {
            foreach (CaminoCambiarZonaTutorial caminoTuto in caminoCambiarZonaTutorials)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(caminoTuto.siguienteEscena);
                string nombreEscena = Path.GetFileNameWithoutExtension(path);

                caminoTuto.nombreSiguienteEscena = nombreEscena;

#if UNITY_EDITOR
                MarcarDirty(caminoTuto);
#endif
            }
        }
        #endregion
#if UNITY_EDITOR
        EditorSceneManager.MarkAllScenesDirty(); // por si acaso
                                                 // Si quieres forzar el guardado de assets:
                                                 // AssetDatabase.SaveAssets();
#endif


    }
    public UnityEngine.Object[] BuscarScripts(Type tipoScript)
    {
        return UnityEngine.Object.FindObjectsByType(tipoScript, FindObjectsInactive.Include, FindObjectsSortMode.None);
    }
    void EntrarLista<T>(UnityEngine.Object[] dados, List<T> listaDestino) where T: MonoBehaviour
    {
        foreach (UnityEngine.Object obj in dados)
        {
            if (obj is T item)
            {
                listaDestino.Add(item);
            }
        }
    }
#if UNITY_EDITOR
    void MarcarDirty(MonoBehaviour componente)
    {
        if (componente == null) return;

        Undo.RecordObject(componente, "Convertir index escena a nombre");
        EditorUtility.SetDirty(componente);
        PrefabUtility.RecordPrefabInstancePropertyModifications(componente);

        // Opcional pero recomendable si quieres que la escena se marque dirty de forma segura
        if (componente.gameObject.scene.IsValid())
            EditorSceneManager.MarkSceneDirty(componente.gameObject.scene);
    }
#endif

}

