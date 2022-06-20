<template>
    <div>
      <v-dialog
        v-model="dialog"
        persistent
        max-width="600px"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            color="primary"
            small
            v-bind="attrs"
            v-on="on"
          >
            Pas thema aan
          </v-btn>
        </template>
        <v-card>
          <v-card-title>
            <span class="headline">Pas thema aan</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-form
                ref="form"
                v-model="valid"
                lazy-validation
              >
                <v-row>
                  <v-col cols="12">
                    <v-color-picker
                      v-model="data.PrimaryColor"
                      dot-size="25"
                      mode="hex"
                      swatches-max-height="200"
                    ></v-color-picker>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-color-picker
                      v-model="data.SecondaryColor"
                      dot-size="25"
                      mode="hex"
                      swatches-max-height="200"
                    ></v-color-picker>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-color-picker
                      v-model="data.TextColor"
                      dot-size="25"
                      mode="hex"
                      swatches-max-height="200"
                    ></v-color-picker>
                  </v-col>
                </v-row>
              </v-form>
            </v-container>
            <small>*verplicht veld</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="blue darken-1"
              text
              @click="dialog = false"
            >
              Sluiten
            </v-btn>
            <v-btn
              color="blue darken-1"
              text
              @click="changeTheme()"
            >
              Pas aan
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
</template>

<script>
import { GET_THEME, UPDATE_THEME } from '../../store/actions.type'

export default {
  data(){
    return {
      dialog: false,
      valid: "",
      data: {
        PrimaryColor: "#FF0000FF",
        SecondaryColor: "#0000FFFF",
        TextColor: "#FFFFFFFF"
      }
    }
  },
  methods: {
    changeTheme: function () {
      if(this.$refs.form.validate()) {
        
        this.$store.dispatch(UPDATE_THEME, { userId: this.$route.params.id, theme: this.data})
        setTimeout(() => {
          this.$store.dispatch(GET_THEME, { userId: this.$route.params.id });
        }, 500);
        this.dialog = false
        //this.$refs.form.reset()
      }
    }
  }
}
</script>
