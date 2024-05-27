<template>
    <q-card style="max-width: 900px;">
      <q-card-section>
        <div class="row flex justify-center items-center" style="font-size: x-large">
          Braço Esquerdo
        </div>
      </q-card-section>
      <div class="row flex justify-center items-center q-mb-sm">
          <q-btn
            label="Relaxar Cotovelo"
            icon="arrow_upward"
            dense
            flat
            @click="contractArm"
          />
      </div>
      <div style="justify-content: space-evenly;" class="row flex justify-center items-center">
        <div>
          <q-btn
            label="Pulso p/ Esquerda"
            icon="rotate_right"
            dense
            flat
            @click="fistPositive"
          />
        </div>
        <div>
          <img
            src="src\images\leftArm.png"
            style="max-height: 350px"
          />
        </div>
        <div>
          <q-btn
            label="Pulso p/ Direita"
            icon="rotate_left"
            dense
            flat
            @click="fistNegative"
          />
        </div>
      </div>
      <div>
        <div class="row flex justify-center items-center q-mt-sm">
          <q-btn
            label="Relaxar Cotovelo"
            icon="arrow_downward"
            dense
            flat
            @click="relaxArm"
          />
        </div>
      </div>
      <div class="q-px-md">
        <q-separator />
      </div>
      <q-card-section>
        <div class="row">
          {{ 'Posição atual do cotovelo: ' }}
          {{ this.armPosition.label }}
        </div>
        <div class="row">
          {{ 'Rotação atual do punho: ' }}
          {{ this.fistRotation.label }}
        </div>
        <div class="row">
          <q-select
            v-model="this.armPosition"
            label="Posição Cotovelo"
            class="col"
            :options="this.armPositions"
            @update:model-value="selectPosition"
          />
          <q-select
            v-model="this.fistRotation"
            label="Rotação Punho"
            class="col"
            :options="this.fistRotations"
            @update:model-value="selectAngle"
          />
        </div>
      </q-card-section>
    </q-card>
  </template>
  
<script>
export default {
  data () {
    return {
      armPositions: [
        { label: 'Em Repouso', value: 0 },
        { label: 'Levemente Contraído', value: 1 },
        { label: 'Contraído', value: 2 },
        { label: 'Fortemente Contraído', value: 3 }
      ],
      armPosition: 'Em Repouso',
      indexArmPosition: 0,
      fistRotations: [
        { label: '-90°', value: -2 },
        { label: '-45°', value: -1 },
        { label: 'Em Repouso', value: 0 },
        { label: '45°', value: 1 },
        { label: '90°', value: 2 },
        { label: '135°', value: 3 },
        { label: '180°', value: 4 },
      ],
      fistRotation: 'Em Repouso',
      indexFistRotation: 2
    }
  },
  mounted () {
    this.armPosition = this.armPositions[0]
    this.fistRotation = this.fistRotations[2]
  },
  methods: {
    contractArm () {
      const positionValue = this.armPosition.value + 1
      this.$axios.post(`https://localhost:7237/api/elbow/left/contract?position=${positionValue}`)
        .then((res) => {
          if (res.data) {
            this.indexArmPosition += 1
            this.armPosition = this.armPositions[this.indexArmPosition]
          }
          else {
            this.indexArmPosition = 0
            this.indexFistRotation = 2
            this.fistRotation = this.fistRotations[2]
            this.armPosition = this.armPositions[0]
            this.$emit('invalidPosition')
          }
        })
    },
    relaxArm () {
      const positionValue = this.armPosition.value -1
      this.$axios.post(`https://localhost:7237/api/elbow/left/contract?position=${positionValue}`)
        .then((res) => {
          if (res.data) {
            this.indexArmPosition -= 1
            this.armPosition = this.armPositions[this.indexArmPosition]
          }
          else {
            this.indexArmPosition = 0
            this.indexFistRotation = 2
            this.fistRotation = this.fistRotations[2]
            this.armPosition = this.armPositions[0]
            this.$emit('invalidPosition')
          }
        })
    },
    fistPositive () {
      const angleValue = this.fistRotation.value + 1
      this.$axios.post(`https://localhost:7237/api/fist/left/rotate?angle=${angleValue}`)
        .then((res) => {
          if (res.data) {
            this.indexFistRotation += 1
            this.fistRotation = this.fistRotations[this.indexFistRotation]
          }
          else {
            this.indexArmPosition = 0
            this.indexFistRotation = 2
            this.fistRotation = this.fistRotations[2]
            this.armPosition = this.armPositions[0]
            this.$emit('invalidPosition')
          }
        })
    },
    fistNegative () {
      const angleValue = this.fistRotation.value - 1
      this.$axios.post(`https://localhost:7237/api/fist/left/rotate?angle=${angleValue}`)
        .then((res) => {
          if (res.data) {
            this.indexFistRotation -= 1
            this.fistRotation = this.fistRotations[this.indexFistRotation]
          }
          else {
            this.indexArmPosition = 0
            this.indexFistRotation = 2
            this.fistRotation = this.fistRotations[2]
            this.armPosition = this.armPositions[0]
            this.$emit('invalidPosition')
          }
        })
    },
    selectPosition () {
      this.$axios.post(`https://localhost:7237/api/elbow/left/contract?position=${this.armPosition.value}`)
        .then((res) => {
          if (res.data) {
            let count = 0
            this.armPositions.forEach((position) => {
              if (position.value === this.armPosition.value) {
                this.indexArmPosition = count
              }
              count++
            })
          }
          else {
            this.indexArmPosition = 0
            this.indexFistRotation = 2
            this.fistRotation = this.fistRotations[2]
            this.armPosition = this.armPositions[0]
            this.$emit('invalidPosition')
          }
        })
    },
    selectAngle () {
      this.$axios.post(`https://localhost:7237/api/fist/left/rotate?angle=${this.fistRotation.value}`)
        .then((res) => {
          if (res.data) {
            let count = 0
            this.fistRotations.forEach((angle) => {
              if (angle.value === this.fistRotation.value) {
                this.indexFistRotation = count
              }
              count++
            })
          }
          else {
            this.indexArmPosition = 0
            this.indexFistRotation = 2
            this.fistRotation = this.fistRotations[2]
            this.armPosition = this.armPositions[0]
            this.$emit('invalidPosition')
          }
        })
    }
  }
}

</script>
