<template>
  <div v-if="error" class="full-screen flex-center">
    <q-card style="max-width: 500px; background-color: grey; color: white">
      <q-card-section>
        <div class="row flex justify-center items-center">
          O sistema do R.O.B.O. foi corrompido devido a um movimento inválido.
        </div>
        <div class="row flex justify-center items-center">
          <q-btn
            label="Reiniciar R.O.B.O."
            style="background-color: green;"
            @click="resetRobot"
          />
        </div>
      </q-card-section>
    </q-card>
  </div>
  <div v-else>
    <div class="row flex justify-center items-center">
      <HeadRobo @invalid-position="invalidMovement"/>
    </div>
    <div class="row flex justify-center items-center">
      <RightArm @invalid-position="invalidMovement"/>
      <q-img
        :src="bodyImage"
        class="col"
        style="max-width: 340px;"
      />
      <LeftArm @invalid-position="invalidMovement"/>
    </div>
  </div>
</template>

<script>
import HeadRobo from '../components/HeadComponent.vue'
import LeftArm from '../components/LeftArmComponent.vue'
import RightArm from '../components/RightArmComponent.vue'
import BodyImage from '../images/bodyImage.png'

export default {
  components: {
    HeadRobo,
    LeftArm,
    RightArm
  },
  data() {
    return {
      bodyImage: BodyImage,
      error: false
    }
  },
  mounted () {
    this.resetRobot()
  },
  methods: {
    resetRobot () {
      this.error = false
      this.$axios.post('https://localhost:7237/api/robot/reset')
    },
    invalidMovement () {
      this.error = true
    }
  }
}
</script>

<style scoped>
.full-screen {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100vw;
}
.flex-center {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
