/*
************************************************************************************************************* 
*    21179 - Laboratório de Desenvolvimento de Software                                                     *
*    1501903 - Rui Miguel Monteiro                                                                          *
*    Modulo: Viewer.cs class - Viewer                                                                         *
*************************************************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Drawing;
using Duality.Components.Renderers;
using Duality.Resources;

namespace TheWall
{
   

    public class Viewer : Component
    {

        public ContentRef<Texture> DefaultBlock_Texture_Ref;
        ContentRef<Pixmap> DefaultBlock_Pixmap_Ref;
        ContentRef<Material> DefaultBlock_Material_Ref;
        //Bola
        ContentRef<Texture> Ball_Texture_Ref;
        ContentRef<Pixmap> Ball_Pixmap_Ref;
        ContentRef<Material> Ball_Material_Ref;
        //Bloco principal/ativo
        ContentRef<Texture> ShipBlock_Texture_Ref;
        ContentRef<Pixmap> ShipBlock_Pixmap_Ref;
        ContentRef<Material> ShipBlock_Material_Ref;
        //Imagem de fundo 
        ContentRef<Texture> SpaceBg_Texture_Ref;
        ContentRef<Pixmap> SpaceBg_Pixmap_Ref;
        ContentRef<Material> SpaceBg_Material_Ref;
        //Scene
        ContentRef<Scene> TheWallScene_Scene_Ref;
        public Viewer()
        {
            // Declaracao dos objetos-recursos usados para o jogo definidos no Editor  

            //Bloco(s)
            DefaultBlock_Texture_Ref = ContentProvider.RequestContent<Texture>(@"Data\DefaultBlock.Texture.res");
            DefaultBlock_Pixmap_Ref = ContentProvider.RequestContent<Pixmap>(@"Data\DefaultBlock.Pixmap.res");
            DefaultBlock_Material_Ref = ContentProvider.RequestContent<Material>(@"Data\DefaultBlock.Material.res");
            //Bola
            Ball_Texture_Ref = ContentProvider.RequestContent<Texture>(@"Data\red_ball.Texture.res");
            Ball_Pixmap_Ref = ContentProvider.RequestContent<Pixmap>(@"Data\red_ball.Pixmap.res");
            Ball_Material_Ref = ContentProvider.RequestContent<Material>(@"Data\red_ball.Material.res");
            //Bloco principal/ativo
            ShipBlock_Texture_Ref = ContentProvider.RequestContent<Texture>(@"Data\ShipBlock.Texture.res");
            ShipBlock_Pixmap_Ref = ContentProvider.RequestContent<Pixmap>(@"Data\ShipBlock.Pixmap.res");
            ShipBlock_Material_Ref = ContentProvider.RequestContent<Material>(@"Data\ShipBlock.Material.res");
            //Imagem de fundo 
            SpaceBg_Texture_Ref = ContentProvider.RequestContent<Texture>(@"Data\SpaceBg.Texture.res");
            SpaceBg_Pixmap_Ref = ContentProvider.RequestContent<Pixmap>(@"Data\SpaceBg.Pixmap.res");
            SpaceBg_Material_Ref = ContentProvider.RequestContent<Material>(@"Data\SpaceBg.Material.res");
            //Scene
            TheWallScene_Scene_Ref = ContentProvider.RequestContent<Scene>(@"Data\TheWallScene.Scene.res");

        }







    }


}
