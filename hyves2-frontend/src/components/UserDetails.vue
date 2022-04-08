<template>
<div>
  {{ userInfo }}
</div>
</template>

<script>
import { GET_USER_INFO } from "../store/actions.type";

export default {
  name: 'UserDetails',
  props: {
    msg: String
  },
  created: function () {
    this.$store.dispatch(GET_USER_INFO, { courtId: this.$route.params.id })
  },
  computed: {
    userInfo(){
        return this.$store.getters.getUserInfo;
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
