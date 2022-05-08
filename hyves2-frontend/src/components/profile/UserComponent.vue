<template>
  <v-container>

        <v-img
        lazy-src="https://picsum.photos/id/11/10/6"
        src="https://picsum.photos/id/11/500/300"
        ></v-img>

        <p class="text-md-center">Bram (666)</p>

        <v-list dense>
          <v-list-item-group
            color="primary"
          >
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/user1_add.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Voeg toe als vriend</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <!-- <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/user1_add.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Tik</v-list-item-title>
              </v-list-item-content>
            </v-list-item> -->
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/mail.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Bericht</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/forbidden.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Blokkeren</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/policeman.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Dit is niet OK!</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-group>
        </v-list>


    
  </v-container>
</template>

<script>
  export default {
    name: 'UserComponent'
  }
</script>
