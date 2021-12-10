<template>
  <showcase-create
    v-bind="createData"
    @onSend="createTTN($event)"
    ref="form"
  />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'

export default {
  name: 'TTNCreate',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      createData: {
        title: 'Создать ТТН',
        fields: [
          {
            label: 'Номер',
            placeholder: 'Номер',
            modelValue: 'number',
            validation: ['required']
          },
          {
            label: 'Дата оформления',
            placeholder: '01.01.1990',
            type: 'date',
            modelValue: 'issueDate',
            validation: ['required']
          },
          {
            label: 'Тип ТТН',
            placeholder: 'Тип ТТН',
            type: 'select',
            modelValue: 'ttnType',
            validation: ['required'],
            values: [
              {
                text: 'Расход',
                value: 'minus'
              },
              {
                text: 'Приход',
                value: 'plus'
              }
            ]
          },
          {
            label: 'Форма ТТН',
            placeholder: 'УТП-12',
            modelValue: 'ttnForm',
            validation: ['required']
          }
        ]
      }
    }
  },
  methods: {
    createTTN (data) {
      console.log(data)
      this.$refs.form.clearForm()
    }
  }
}
</script>
