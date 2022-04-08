<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <UserDetails />
  </div>
</template>

<script>
// @ is an alias to /src
import UserDetails from '@/components/UserDetails.vue'

export default {
  name: 'HomeView',
  components: {
    UserDetails
  }
}
</script>
