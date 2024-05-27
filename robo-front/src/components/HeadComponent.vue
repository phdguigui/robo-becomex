<template>
  <q-card style="max-width: 800px;">
    <q-card-section>
      <div class="row flex justify-center items-center" style="font-size: x-large">
        Cabeça
      </div>
    </q-card-section>
    <div class="row flex justify-center items-center q-mb-sm">
        <q-btn
          label="Inclinar para cima"
          icon="arrow_upward"
          dense
          flat
          @click="headUp"
        />
    </div>
    <div style="justify-content: space-evenly;" class="row flex justify-center items-center">
      <div>
        <q-btn
          label="Rotacionar p/ Direita"
          icon="rotate_right"
          dense
          flat
          @click="headRight"
        />
      </div>
      <div>
        <img
          :src="roboImage"
          style="max-width: 200px"
        />
      </div>
      <div>
        <q-btn
          label="Rotacionar p/ Esquerda"
          icon="rotate_left"
          dense
          flat
          @click="headLeft"
        />
      </div>
    </div>
    <div>
      <div class="row flex justify-center items-center q-mt-sm">
        <q-btn
          label="Inclinar para Baixo"
          icon="arrow_downward"
          dense
          flat
          @click="headDown"
        />
      </div>
    </div>
    <div class="q-px-md">
      <q-separator />
    </div>
    <q-card-section>
      <div class="row">
        {{ 'Rotação atual: ' }}
        {{ this.headRotation.label }}
      </div>
      <div class="row">
        {{ 'Inclinação atual: ' }}
        {{ this.headPosition.label }}
      </div>
      <div class="row">
        <q-select
          v-model="this.headRotation"
          label="Rotação"
          class="col"
          :options="this.headRotations"
          @update:model-value="selectAngle"
        />
        <q-select
          v-model="this.headPosition"
          label="Inclinação"
          class="col"
          :options="this.headPositions"
          @update:model-value="selectPosition"
        />
      </div>
    </q-card-section>
  </q-card>
</template>

<script>
export default {
  data () {
    return {
      headPositions: [
        { label: 'Para Baixo', value: -1 },
        { label: 'Em Repouso', value: 0 },
        { label: 'Para Cima', value: 1 }
      ],
      headPosition: 'Em Repouso',
      indexHeadPosition: 1,
      headRotations: [
        { label: '-90°', value: -2 },
        { label: '-45°', value: -1 },
        { label: 'Em Repouso', value: 0 },
        { label: '45°', value: 1 },
        { label: '90°', value: 2 }
      ],
      headRotation: 'Em Repouso',
      indexHeadRotation: 2,
      roboImage: 'src\\images\\headImage.png'
    }
  },
  mounted () {
    this.headPosition = this.headPositions[1]
    this.headRotation = this.headRotations[2]
  },
  updated () {
    console.log('updated')
  },
  methods: {
    headUp () {
      const positionValue = this.headPosition.value + 1
      this.$axios.post(`https://localhost:7237/api/head/incline?position=${positionValue}`)
        .then((res) => {
          if (res.data) {
            this.indexHeadPosition += 1
            this.headPosition = this.headPositions[this.indexHeadPosition]
          }
          else {
            this.indexHeadPosition = 1
            this.indexHeadRotation = 2
            this.headRotation = this.headRotations[2]
            this.headPosition = this.headPositions[1]
            this.$emit('invalidPosition')
          }
        })
    },
    headDown () {
      const positionValue = this.headPosition.value - 1
      this.$axios.post(`https://localhost:7237/api/head/incline?position=${positionValue}`)
        .then((res) => {
          if (res.data) {
            this.indexHeadPosition -= 1
            this.headPosition = this.headPositions[this.indexHeadPosition]
          }
          else {
            this.indexHeadPosition = 1
            this.indexHeadRotation = 2
            this.headRotation = this.headRotations[2]
            this.headPosition = this.headPositions[1]
            this.$emit('invalidPosition')
          }
        })
    },
    headRight () {
      const angleValue = this.headRotation.value + 1
      this.$axios.post(`https://localhost:7237/api/head/rotate?angle=${angleValue}`)
      .then((res) => {
        if (res.data) {
          this.indexHeadRotation += 1
          this.headRotation = this.headRotations[this.indexHeadRotation]

          if (this.indexHeadRotation <= 1){
            this.roboImage = 'src\\images\\headImageLeft.png'
          }
          if (this.indexHeadRotation === 2){
            this.roboImage = 'src\\images\\headImage.png'
          }
          if (this.indexHeadRotation >= 3){
            this.roboImage = 'src\\images\\headImageRight.png'
          }
        }
        else {
          this.indexHeadPosition = 1
          this.indexHeadRotation = 2
          this.headRotation = this.headRotations[2]
          this.headPosition = this.headPositions[1]
          this.$emit('invalidPosition')
        }
      })
    },
    headLeft () {
      const angleValue = this.headRotation.value - 1
      console.log('angleValue', angleValue)
      this.$axios.post(`https://localhost:7237/api/head/rotate?angle=${angleValue}`)
        .then((res) => {
          console.log('res', res)
          if (res.data) {
            this.indexHeadRotation -= 1
            this.headRotation = this.headRotations[this.indexHeadRotation]

            if (this.indexHeadRotation <= 1){
              this.roboImage = 'src\\images\\headImageLeft.png'
            }
            if (this.indexHeadRotation === 2){
              this.roboImage = 'src\\images\\headImage.png'
            }
            if (this.indexHeadRotation >= 3){
              this.roboImage = 'src\\images\\headImageRight.png'
            }
          }
          else {
            this.indexHeadPosition = 1
            this.indexHeadRotation = 2
            this.headRotation = this.headRotations[2]
            this.headPosition = this.headPositions[1]
            this.$emit('invalidPosition')
          }
        })
      
    },
    selectPosition () {
      this.$axios.post(`https://localhost:7237/api/head/incline?position=${this.headPosition.value}`)
        .then((res) => {
          if (res.data) {
            let count = 0
            this.headPositions.forEach((position) => {
              if (position.value === this.headPosition.value) {
                this.indexHeadPosition = count
              }
              count++
            })
          }
          else {
            this.indexHeadPosition = 1
            this.indexHeadRotation = 2
            this.headRotation = this.headRotations[2]
            this.headPosition = this.headPositions[1]
            this.$emit('invalidPosition')
          }
        })
    },
    selectAngle () {
      this.$axios.post(`https://localhost:7237/api/head/rotate?angle=${this.headRotation.value}`)
        .then((res) => {
          if (res.data) {
            let count = 0
            this.headRotations.forEach((angle) => {
              if (angle.value === this.headRotation.value) {
                this.indexHeadRotation = count
              }
              count++
            })

            if (this.indexHeadRotation <= 1){
              this.roboImage = 'src\\images\\headImageLeft.png'
            }
            if (this.indexHeadRotation === 2){
              this.roboImage = 'src\\images\\headImage.png'
            }
            if (this.indexHeadRotation >= 3){
              this.roboImage = 'src\\images\\headImageRight.png'
            }
          }
          else {
            this.indexHeadPosition = 1
            this.indexHeadRotation = 2
            this.headRotation = this.headRotations[2]
            this.headPosition = this.headPositions[1]
            this.$emit('invalidPosition')
          }
        })
    }
  }
}


</script>
