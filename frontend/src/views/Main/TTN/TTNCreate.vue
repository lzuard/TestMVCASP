<template>
  <showcase-create v-bind="createData" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'

export default {
  name: 'AgentCreate',
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
            modelValue: 'number'
          },
          {
            label: 'Дата оформления',
            placeholder: '01.01.1990',
            type: 'date',
            modelValue: 'issueDate'
          },
          {
            label: 'Тип ТТН',
            placeholder: 'Тип ТТН',
            type: 'select',
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
            modelValue: 'ttnForm'
          }
        ]
      }
    }
  }
}
</script>
