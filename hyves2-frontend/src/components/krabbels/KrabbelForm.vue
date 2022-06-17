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
            Stuur krabbel
          </v-btn>
        </template>
        <v-card>
          <v-card-title>
            <span class="headline">Stuur krabbel</span>
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
                    <v-text-field
                        label="Text"
                        v-model="datafields.text"
                        type="text"
                        :rules="rules.text"
                        required
                    ></v-text-field>
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
              @click="addMoney()"
            >
              Stuur krabbel
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
</template>

<script>
import { CREATE_KRABBEL, GET_KRABBELS_BY_USER, GET_USER_BY_ID } from '../../store/actions.type'

export default {
  data(){
    return {
      dialog: false,
      valid: "",
      datafields: {
        amount: ""
      },
      rules: {
        amount: [
          v => !!v || 'Amount is verplicht',
          v => (v && v.length >= 4) || 'Moet langer dan 4 karakters zijn.',
        ]
      }
    }
  },
  methods: {
    addMoney: function () {
      if(this.$refs.form.validate()) {
        this.$store.dispatch(CREATE_KRABBEL, { userId: this.$route.params.id, data: this.datafields})
        setTimeout(() => {
          this.$store.dispatch(GET_KRABBELS_BY_USER, { userId: this.$route.params.id });
          this.$store.dispatch(GET_USER_BY_ID, { userId: this.$route.params.id });
        }, 500);
        this.dialog = false
        this.$refs.form.reset()
      }
    }
  }
}
</script>
